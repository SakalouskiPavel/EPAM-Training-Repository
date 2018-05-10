using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2018.Соколовский._21
{
    public sealed class BankAccount : IBankAccount, IDisposable
    {
        private CustomContext _context;

        private DbSet<BankAccount> _bankAccounts;

        private Logger _logger;

        private bool _disposed;

        public BankAccount()
        {
            this._context = new CustomContext();
            this._logger = new Logger();
            this._bankAccounts = _context.Set<BankAccount>();
        }

        public BankAccount(CustomContext context, Logger logger)
        {
            this._context = context;
            this._logger = logger;
            this._bankAccounts = _context.Set<BankAccount>();
        }

        public int AccountId { get; set; }

        public string OwnerFirstName { get; set; }

        public string OwnerLastName { get; set; }

        public decimal Ammount { get; set; }

        public bool IsClosed { get; set; }

        public BankAccount CloseAnAccount(int accountId)
        {
            var updatedBankAccount = Get(accountId);
            if (ReferenceEquals(updatedBankAccount, null))
            {
                throw new ArgumentException(nameof(accountId));
            }

            updatedBankAccount.IsClosed = true;
            this._logger.Log("Update successfull");
            return Update(updatedBankAccount);
        }

        public BankAccount Withdraw(decimal amount, int accountId)
        {
            var updatedBankAccount = Get(accountId);
            if (ReferenceEquals(updatedBankAccount, null))
            {
                throw new ArgumentException(nameof(accountId));
            }

            updatedBankAccount.Ammount = updatedBankAccount.Ammount - amount;
            this._logger.Log("Withdraw successfull");
            return Update(updatedBankAccount);
        }

        public BankAccount Deposit(decimal amount, int accountId)
        {
            var updatedBankAccount = Get(accountId);
            if (ReferenceEquals(updatedBankAccount, null))
            {
                throw new ArgumentException(nameof(accountId));
            }

            updatedBankAccount.Ammount = updatedBankAccount.Ammount + amount;
            this._logger.Log("Deposit successfull");
            return Update(updatedBankAccount);
        }

        public void AddAccount(BankAccount account)
        {
            _bankAccounts.Add(account);
            _context.SaveChanges();
            this._logger.Log("account was added");
        }

        public IEnumerable<BankAccount> GetAll()
        {
            return _bankAccounts.ToList();
        }

        public void RemoveAccount(BankAccount account)
        {
            _bankAccounts.Remove(account);
            _context.SaveChanges();
            this._logger.Log("account was removed");
        }

        public BankAccount Update(BankAccount account)
        {
            var entity = Get(account.AccountId);
            entity = account;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            this._logger.Log("account was updated");
            return entity;
        }

        public BankAccount Get(int accountId)
        {
            return _bankAccounts.SingleOrDefault(a => a.AccountId == accountId);
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
