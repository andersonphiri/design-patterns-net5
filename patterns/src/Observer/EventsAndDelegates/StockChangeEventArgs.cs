using System;

namespace Observer.EventsAndDelegates
{
    public class StockChangeEventArgs : EventArgs
    {
        public StockChangeEventArgs(Stock s)
        {
            this.Stock = s;
        }
        public Stock Stock { get; set; }
    }
}
