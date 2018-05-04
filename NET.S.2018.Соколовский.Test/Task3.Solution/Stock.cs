using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Stock : IObservable
    {
        private StockInfo stocksInfo;

        public event EventHandler Event;

        public Stock()
        {
            stocksInfo = new StockInfo();
        }

        public void Market()
        {
            Random rnd = new Random();
            stocksInfo.USD = rnd.Next(20, 40);
            stocksInfo.Euro = rnd.Next(30, 50);
            Event?.Invoke(stocksInfo, new EventArgs());
        }
    }
}
