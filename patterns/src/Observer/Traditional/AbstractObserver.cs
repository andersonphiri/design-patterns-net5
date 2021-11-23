using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Traditional
{
    public abstract class AbstractObserver
    {
        public abstract void Update();
    }
    public abstract class AbstractSubject
    {
        List<AbstractObserver> observers = new List<AbstractObserver>();
        public void Register(AbstractObserver observer)
        {
            observers.Add(observer);
        }
        public void UnRegister(AbstractObserver observer) => observers.Remove(observer);
        public void Notify() => observers.ForEach(o => o.Update());
    }
    // observers
    public class GoogleObserver : AbstractObserver
    {
        public GoogleObserver(StockTicker subj)
        {
            this.DataSource = subj;
            subj.Register(this);
        }
        private StockTicker DataSource { get; set; }
        public override void Update()
        {
            decimal price = DataSource.Stock.Price;
            string symbol = DataSource.Stock.Symbol;

            // Reactive Filters
            if (symbol == "GOOG")
                Console.WriteLine("Google's new price is: {0}", price);
        }
    }
    public class MicrosoftObserver : AbstractObserver
    {
        private StockTicker DataSource { get; set; }

        public MicrosoftObserver(StockTicker subj)
        {
            this.DataSource = subj;
            subj.Register(this);
        }

        public override void Update()
        {
            decimal price = DataSource.Stock.Price;
            string symbol = DataSource.Stock.Symbol;

            // Reactive Filters
            if (symbol == "MSFT" && price > 10.00m)
                Console.WriteLine("Microsoft has reached the target price: {0}", price);
        }
    }
}
