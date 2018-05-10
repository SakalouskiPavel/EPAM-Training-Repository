using System.Collections.Generic;

namespace NET.W._2018.Соколовский._21
{
    public interface IBankAccount
    {
        int AccountId { get; set; }

        string OwnerFirstName { get; set; }

        string OwnerLastName { get; set; }

        decimal Ammount { get; set; }

        bool IsClosed { get; set; }

        BankAccount CloseAnAccount(int accountId);

        BankAccount Withdraw(decimal amount, int accountId);

        BankAccount Deposit(decimal amount, int accountId);

        void AddAccount(BankAccount account);

        IEnumerable<BankAccount> GetAll();

        void RemoveAccount(BankAccount account);

        BankAccount Update(BankAccount account);

        BankAccount Get(int accountId);
    }
}