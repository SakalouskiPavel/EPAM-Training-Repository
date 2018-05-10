using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace NET.W._2018.Соколовский._21
{
    class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolve();
        }

        static void Main(string[] args)
        {
            using (Resolver)
            {
                IBankAccount b1 = Resolver.Get<IBankAccount>();
                IBankAccount b2 = Resolver.Get<IBankAccount>();
                b1.AddAccount((BankAccount)b2);
            }

        }
    }
}
