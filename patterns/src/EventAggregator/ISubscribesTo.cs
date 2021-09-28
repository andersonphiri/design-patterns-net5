namespace EventAggregator
{
    public interface ISubscribesTo<TEvent>
    {
        void OnEvent(TEvent @event);
    }
}
