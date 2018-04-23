using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IBankAccountService
    {
        BankAccount Deposit(decimal amount, int accountId);

        BankAccount Withdraw(decimal amount, int accountId);

        BankAccount AddAccount(BankAccount bankAccount);

        BankAccount RemoveAccount(BankAccount bankAccount);

        BankAccount CloseAnAccount(int accountId);

        IEnumerable<BankAccount> GetAllBankAccounts();
    }
}