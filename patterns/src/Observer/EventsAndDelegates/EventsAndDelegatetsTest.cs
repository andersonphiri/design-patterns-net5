using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.EventsAndDelegates
{
    public class EventsAndDelegatetsTest
    {
        public void Run()
        {
            // Monitor a stock ticker, when particular events occur, react
            StockTicker st = new StockTicker();

            // Create New observers to listen to the stock ticker
            GoogleMonitor gf = new GoogleMonitor(st);
            MicrosoftMonitor mf = new MicrosoftMonitor(st);

            // Load the Sample Stock Data
            foreach (var s in SampleData.getNext())
                st.Stock = s;
        }
    }
}
