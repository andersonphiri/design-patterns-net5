using LazyLoad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.ValueHolder
{
    /// <summary>
    /// NOte: you may still achieve the same result using Lazy<T>
    /// </summary>
    public class OrderValueHolder
    {
        public int Id { get; set; }
        public OrderValueHolder(int id)
        {
            Id = id;
        }
        private ValueHolder<List<OrderItem>> _items;
        public List<OrderItem> Items { get => _items.Value;  }
        internal void SetItems(ValueHolder<List<OrderItem>> items) => _items = items;
    }

    public interface IValueLoader<T>
    {
        T Load();
    }

    public class ValueHolder<T>
    {
        private T _value;
        private readonly IValueLoader<T> _loader;
        public ValueHolder(IValueLoader<T> loader)
        {
            _loader = loader;
        }
        public T Value
        {
            get => _value ?? (_value = _loader.Load());
        }
    }
    public class OrderItemloader : IValueLoader<List<OrderItem>>
    {
        private readonly int _orderId;
        public OrderItemloader(int orderId)
        {
            _orderId = orderId;
        }
        public List<OrderItem> Load()
        {
            return new List<OrderItem>();
        }
    }

    public class OrderFactory
    {
       public OrderValueHolder CreateFromId(int id)
        {
            var oder = new OrderValueHolder(id);
            oder.SetItems(new ValueHolder<List<OrderItem>>(new OrderItemloader(id)));
            return oder;
        }
    }

}
