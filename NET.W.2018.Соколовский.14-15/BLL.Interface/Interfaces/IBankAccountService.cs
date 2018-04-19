using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IBankAccountService
    {
        BankAccount TopUpInAnAccount(decimal amount, int accountId);

        BankAccount DebitTheAccount(decimal amount, int accountId);

        BankAccount AddAccount(BankAccount bankAccount);

        BankAccount RemoveAccount(BankAccount bankAccount);

        BankAccount CloseAnAccount(int accountId);

        IEnumerable<BankAccount> GetAllBankAccounts();
    }
}