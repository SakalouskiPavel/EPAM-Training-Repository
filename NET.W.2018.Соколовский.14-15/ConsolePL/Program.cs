using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {

        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolve();
        }

        static void Main(string[] args)
        {
            IBankAccountService bankAccountService = resolver.Get<IBankAccountService>();
            var newBankAccount = new BankAccount(1, "FirstName", "LastName", 20, 0, false, BankAccountTypes.Standart, 10);
            Console.WriteLine(bankAccountService.AddAccount(newBankAccount));
            newBankAccount = new BankAccount(2, "FirstName2", "LastName2", 22, 3, false, BankAccountTypes.Gold, 20);
            Console.WriteLine(bankAccountService.AddAccount(newBankAccount));
            var bankAccountsList = bankAccountService.GetAllBankAccounts();
            bankAccountService.TopUpInAnAccount(30, bankAccountsList.ToList()[0].AccountId);
            bankAccountService.DebitTheAccount(10, bankAccountsList.ToList()[1].AccountId);

            Console.ReadKey();
        }
    }
}
