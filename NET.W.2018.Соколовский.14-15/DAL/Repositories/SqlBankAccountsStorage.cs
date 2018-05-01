using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public class SqlBankAccountsStorage : IBankAccountsRepository
    {
        private DbContext _context;

        private DbSet<BankAccountDTO> _bankAccounts;

        private bool _disposed;

        public SqlBankAccountsStorage(DbContext context)
        {
            this._context = context;
            this._bankAccounts = this._context.Set<BankAccountDTO>();
        }

        public BankAccountDTO Get(int accountId)
        {
            return this._bankAccounts.SingleOrDefault(a => a.AccountId == accountId);
        }

        public BankAccountDTO Add(BankAccountDTO bankAccount)
        {
            var result = this._bankAccounts.Add(bankAccount);
            this._context.SaveChanges();
            return result;
        }

        public BankAccountDTO Update(BankAccountDTO bankAccount)
        {
            var entity = Get(bankAccount.AccountId);
            entity = bankAccount;
            this._context.Entry(entity).State = EntityState.Modified;
            this._context.SaveChanges();
            return entity;
        }

        public BankAccountDTO Delete(BankAccountDTO bankAccount)
        {
            var result = this._bankAccounts.Remove(bankAccount);
            this._context.SaveChanges();
            return result;
        }

        public IEnumerable<BankAccountDTO> GetAll()
        {
            return this._bankAccounts.ToList();
        }

        public void Dispose()
        {
            Dispose(true);
        }
       
        private void Dispose(bool flag)
        {
            if (_disposed)
            {
                return;
            }

            _context.Dispose();
            _disposed = true;

            if (flag)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}