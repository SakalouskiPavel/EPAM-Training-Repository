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
    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolve();
        }

        public static void Main(string[] args)
        {
            IBankAccountService bankAccountService = Resolver.Get<IBankAccountService>();
            var newBankAccount = new BankAccount(1, "FirstName", "LastName", 20, 0, false, BankAccountTypes.Standart, 10);
            Console.WriteLine(bankAccountService.AddAccount(newBankAccount));
            newBankAccount = new BankAccount(2, "FirstName2", "LastName2", 22, 3, false, BankAccountTypes.Gold, 20);
            Console.WriteLine(bankAccountService.AddAccount(newBankAccount));
            var bankAccountsList = bankAccountService.GetAllBankAccounts();
            bankAccountService.Deposit(30, bankAccountsList.ToList()[0].AccountId);
            bankAccountService.Withdraw(10, bankAccountsList.ToList()[1].AccountId);

            Console.ReadKey();
        }
    }
}