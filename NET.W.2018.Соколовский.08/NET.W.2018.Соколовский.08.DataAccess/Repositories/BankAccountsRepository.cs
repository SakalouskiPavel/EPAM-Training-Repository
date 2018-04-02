using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NET.W._2018.Соколовский._08.Common;
using NET.W._2018.Соколовский._08.Common.Exceptions;
using NET.W._2018.Соколовский._08.Common.Interfaces.Repositories;
using NET.W._2018.Соколовский._08.Common.Models;

namespace NET.W._2018.Соколовский._08.DataAccess.Repositories
{
    public class BankAccountsRepository : IBankAccountsRepository
    {
        private string _storagePath;

        private IEnumerable<BankAccount> _storage;

        public BankAccountsRepository(string storagePath)
        {
            this._storagePath = storagePath;
            this._storage = this.LoadStorage();
        }

        public BankAccount Add(BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            if (this._storage.Any((a) => a.AccountId == bankAccount.AccountId))
            {
                throw new AlreadyExistInStorageException();
            }

            this._storage = this._storage.Concat(new List<BankAccount>() { bankAccount });
            this.SaveStorage();
            return bankAccount;
        }

        public BankAccount Delete(BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            this._storage = this._storage.Except(new List<BankAccount>() { bankAccount });
            SaveStorage();
            return bankAccount;
        }

        public BankAccount Get(int accountId)
        {
            return this._storage?.FirstOrDefault((a) => a.AccountId == accountId);
        }

        public IEnumerable<BankAccount> GetAll()
        {
            return this._storage.ToList();
        }

        public BankAccount Update(BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            var updatedBankAccount = this._storage.FirstOrDefault((a) => a.AccountId == bankAccount.AccountId);

            if (!ReferenceEquals(updatedBankAccount, null))
            {
                this._storage = this._storage.Except(new List<BankAccount>() {updatedBankAccount});
            }

            this._storage = this._storage.Concat(new List<BankAccount>() { bankAccount });
            SaveStorage();
            return bankAccount;
        }

        private IEnumerable<BankAccount> LoadStorage()
        {
            var result = new List<BankAccount>();
            using (var currentFileStream = new FileStream(_storagePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (var currentBinaryReader = new BinaryReader(currentFileStream))
                {
                    while (currentBinaryReader.BaseStream.Position != currentBinaryReader.BaseStream.Length)
                    {
                        var accountId = currentBinaryReader.ReadInt32();
                        var ammount = currentBinaryReader.ReadDecimal();
                        var bonus = currentBinaryReader.ReadInt32();
                        var isClosed = currentBinaryReader.ReadBoolean();
                        var ownerFirstName = currentBinaryReader.ReadString();
                        var ownerLastName = currentBinaryReader.ReadString();
                        BankAccountTypes bankAccountType = (BankAccountTypes)currentBinaryReader.ReadInt32();
                        var bonusRate = currentBinaryReader.ReadInt32();
                        var loadedBankAccount = new BankAccount(accountId, ownerFirstName, ownerLastName, ammount, bonus, isClosed, bankAccountType, bonusRate);
                        result.Add(loadedBankAccount);
                    }
                }
            }

            return result;
        }

        private void SaveStorage()
        {
            using (var currentFileStream = new FileStream(_storagePath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (var currentBinaryWriter = new BinaryWriter(currentFileStream))
                {
                    foreach (var bankAccount in _storage)
                    {
                        currentBinaryWriter.Write(bankAccount.AccountId);
                        currentBinaryWriter.Write(bankAccount.Ammount);
                        currentBinaryWriter.Write(bankAccount.Bonus);
                        currentBinaryWriter.Write(bankAccount.IsClosed);
                        currentBinaryWriter.Write(bankAccount.OwnerFirstName);
                        currentBinaryWriter.Write(bankAccount.OwnerLastName);
                        currentBinaryWriter.Write((int)bankAccount.BankAccountType);
                        currentBinaryWriter.Write(bankAccount.BonusRate);
                    }
                }
            }
        }
    }
}