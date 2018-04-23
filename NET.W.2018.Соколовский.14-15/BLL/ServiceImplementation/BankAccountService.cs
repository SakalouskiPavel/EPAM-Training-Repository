using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Interface;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Enums;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class BankAccountService : IBankAccountService
    {
        private IBankAccountsRepository _storage;

        public BankAccountService(IBankAccountsRepository storage)
        {
            this._storage = storage;
        }

        /// <summary>
        /// Add new account.
        /// </summary>
        /// <param name="bankAccount"> Added account.</param>
        /// <returns></returns>
        public BankAccount AddAccount(BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }
            
            return Mapper.Map<BankAccount>(this._storage.Add(Mapper.Map<BankAccountDTO>(bankAccount)));
        }

        /// <summary>
        /// Make account closed.
        /// </summary>
        /// <param name="accountId"> Unique account identifier.</param>
        /// <returns></returns>
        public BankAccount CloseAnAccount(int accountId)
        {
            var updatedBankAccount = this._storage.Get(accountId);
            if (ReferenceEquals(updatedBankAccount, null))
            {
                throw new ArgumentException(nameof(accountId));
            }

            updatedBankAccount.IsClosed = true;
            return Mapper.Map<BankAccount>(this._storage.Update(updatedBankAccount));
        }

        /// <summary>
        /// Withdraw money from an account.
        /// </summary>
        /// <param name="amount"> Withdraw amount.</param>
        /// <param name="accountId"> Unique account identifier.</param>
        /// <returns></returns>
        public BankAccount Withdraw(decimal amount, int accountId)
        {
            var updatedBankAccount = this._storage.Get(accountId);
            updatedBankAccount.Ammount = updatedBankAccount.Ammount + updatedBankAccount.Bonus - amount;
            return Mapper.Map<BankAccount>(this._storage.Update(updatedBankAccount));
        }

        /// <summary>
        /// Remove an account from storage.
        /// </summary>
        /// <param name="bankAccount"> Removed account.</param>
        /// <returns></returns>
        public BankAccount RemoveAccount(BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            return Mapper.Map<BankAccount>(this._storage.Delete(Mapper.Map<BankAccountDTO>(bankAccount)));
        }

        /// <summary>
        /// Deposit money to account.
        /// </summary>
        /// <param name="amount"> Deposit amount.</param>
        /// <param name="accountId"> Unique account identifier.</param>
        /// <returns></returns>
        public BankAccount Deposit(decimal amount, int accountId)
        {
            var updatedBankAccount = this._storage.Get(accountId);
            if (ReferenceEquals(updatedBankAccount, null))
            {
                throw new ArgumentException(nameof(accountId));
            }

            updatedBankAccount.Ammount = updatedBankAccount.Ammount + updatedBankAccount.Bonus + amount;
            return Mapper.Map<BankAccount>(this._storage.Update(updatedBankAccount));
        }

        /// <summary>
        /// Gets all account from storage.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BankAccount> GetAllBankAccounts()
        {
            return Mapper.Map<IEnumerable<BankAccount>>(this._storage.GetAll());
        }
    }
}