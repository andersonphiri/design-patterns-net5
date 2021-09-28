using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EventAggregator
{
    public class EventAggregatorDefault : IEventAggregator
    {
        private readonly Dictionary<Type, List<WeakReference>> _eventSubscriberLists = new();
        private readonly object _lock = new object();

        public void Subscribe(object subscriber)
        {
            lock (_lock)
            {
                var subscriberTypes = subscriber.GetType().GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubscribesTo<>));
                var weakReference = new WeakReference(subscriber);
                foreach (var subscriberType in subscriberTypes)
                {
                    var subscribers = GetSubscribers(subscriberType);
                    subscribers.Add(weakReference);
                }

            }
        }

        public void Publish<TEvent>(TEvent eventToPublish)
        {
            var subscriberType = typeof(ISubscribesTo<>).MakeGenericType(typeof(TEvent));
            var subscribers = GetSubscribers(subscriberType);
            List<WeakReference> subscribersToRemove = new();

            foreach (var weakSubscriber in subscribers)
            {
                if (weakSubscriber.IsAlive)
                {
                    var subscriber = (ISubscribesTo<TEvent>)weakSubscriber.Target;
                    var syncContext = SynchronizationContext.Current ?? new SynchronizationContext();
                    syncContext.Post(s => subscriber.OnEvent(eventToPublish), null);
                }
                else
                {
                    subscribersToRemove.Add(weakSubscriber);
                }
            }
            if(subscribersToRemove.Any())
            {
                lock (_lock)
                {
                    subscribersToRemove.ForEach(s => subscribers.Remove(s));
                }
            }
        }

        private List<WeakReference> GetSubscribers(Type subscriberType)
        {
            List<WeakReference> subscribers;
            lock (_lock)
            {
                var found = _eventSubscriberLists.TryGetValue(subscriberType, out subscribers);
                if (!found)
                {
                    subscribers = new();
                    _eventSubscriberLists.Add(subscriberType, subscribers);
                }
            }
            return subscribers;
        }

       
    }
}
