using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Broker : IObserver
    {
        private IObservable stock;

        public string Name { get; set; }

        public Broker(string name, IObservable observable)
        {
            this.Name = name;
            stock = observable;
            stock.Event += Update;
        }

        public void Update(object info, EventArgs args)
        {
            StockInfo sInfo = (StockInfo)info;

            if (sInfo.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
        }

        public void StopTrade()
        {
            stock.Event -= Update;
            stock = null;
        }
    }
}
