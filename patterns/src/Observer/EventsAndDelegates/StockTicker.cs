using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.EventsAndDelegates
{
    public class StockTicker
    {
        private Stock stock;
        public Stock Stock
        {
            get { return stock; }
            set
            {
                stock = value;
                this.OnStockChange(new StockChangeEventArgs(this.stock));
            }
        }

        public event EventHandler<StockChangeEventArgs> StockChange;

        protected virtual void OnStockChange(StockChangeEventArgs e)
        {
            StockChange?.Invoke(this, e);
        }
    }

}
