using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Bank bank = new Bank("Name", stock);
            Broker broker = new Broker("Broker", stock);

            stock.Market();
            System.Console.ReadKey();
        }
    }
}
