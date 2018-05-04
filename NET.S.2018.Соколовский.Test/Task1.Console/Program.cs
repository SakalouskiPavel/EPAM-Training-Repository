
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Task1.Solution.DependecyResolver;
using Task1.Solution.Interfaces;

namespace Task1.Console
{
    using System;
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
            IPasswordCheckerService servie = Resolver.Get<IPasswordCheckerService>();
            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                var result = servie.VerifyPassword(password);
                foreach (Tuple<bool, string> tuple in result)
                {
                    if (tuple.Item1)
                    {
                        flag = true;
                    }

                    Console.WriteLine(tuple.Item2);
                }
            }

            Console.ReadKey();
        }
    }
}
