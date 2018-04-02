using System;
using System.Collections.Generic;
using NET.W._2018.Соколовский._08.Common.Interfaces.Repositories;
using NET.W._2018.Соколовский._08.Common.Interfaces.Services;
using NET.W._2018.Соколовский._08.Common.Models;

namespace NET.W._2018.Соколовский._08.BusinessLogic.Services
{
    public class BankAccountService : IBankAccountService
    {
        private IBankAccountsRepository _storage;

        public BankAccountService(IBankAccountsRepository storage)
        {
            this._storage = storage;
        }
        public BankAccount AddAccount(BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            return this._storage.Add(bankAccount);
        }

        public BankAccount CloseAnAccount(int accountId)
        {
            var updatedBankAccount = this._storage.Get(accountId);
            if (ReferenceEquals(updatedBankAccount, null))
            {
                throw new ArgumentException(nameof(accountId));
            }

            updatedBankAccount.IsClosed = true;
            return this._storage.Update(updatedBankAccount);
        }

        public BankAccount DebitTheAccount(decimal amount, int accountId)
        {
            var updatedBankAccount = this._storage.Get(accountId);
            updatedBankAccount.Ammount = updatedBankAccount.Ammount + updatedBankAccount.Bonus - amount;
            return this._storage.Update(updatedBankAccount);
        }

        public BankAccount RemoveAccount(BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            return this._storage.Delete(bankAccount);
        }

        public BankAccount TopUpInAnAccount(decimal amount, int accountId)
        {
            var updatedBankAccount = this._storage.Get(accountId);
            if (ReferenceEquals(updatedBankAccount, null))
            {
                throw new ArgumentException(nameof(accountId));
            }
            updatedBankAccount.Ammount = updatedBankAccount.Ammount + updatedBankAccount.Bonus + amount;
            return this._storage.Update(updatedBankAccount);
        }

        public IEnumerable<BankAccount> GetAllBankAccounts()
        {
            return this._storage.GetAll();
        }
    }
}