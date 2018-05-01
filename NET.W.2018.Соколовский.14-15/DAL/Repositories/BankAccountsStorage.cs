using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BLL.Interface;
using BLL.Interface.Exceptions;
using DAL.Interface.DTO;
using DAL.Interface.Enums;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public class BankAccountsStorage : IBankAccountsRepository
    {
        private string _storagePath;

        private IEnumerable<BankAccountDTO> _storage;

        public BankAccountsStorage(string storagePath)
        {
            this._storagePath = storagePath;
            this._storage = this.LoadStorage();
        }

        public BankAccountDTO Add(BankAccountDTO bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            if (this._storage.Any((a) => a.AccountId == bankAccount.AccountId))
            {
                throw new AlreadyExistInStorageException();
            }

            this._storage = this._storage.Concat(new List<BankAccountDTO>() { bankAccount });
            this.SaveStorage();
            return bankAccount;
        }

        public BankAccountDTO Delete(BankAccountDTO bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            this._storage = this._storage.Except(new List<BankAccountDTO>() { bankAccount });
            SaveStorage();
            return bankAccount;
        }

        public BankAccountDTO Get(int accountId)
        {
            return this._storage?.FirstOrDefault((a) => a.AccountId == accountId);
        }

        public IEnumerable<BankAccountDTO> GetAll()
        {
            return this._storage.ToList();
        }

        public BankAccountDTO Update(BankAccountDTO bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            var updatedBankAccount = this._storage.FirstOrDefault((a) => a.AccountId == bankAccount.AccountId);
            if (!ReferenceEquals(updatedBankAccount, null))
            {
                this._storage = this._storage.Except(new List<BankAccountDTO>() { updatedBankAccount });
            }

            this._storage = this._storage.Concat(new List<BankAccountDTO>() { bankAccount });
            SaveStorage();
            return bankAccount;
        }

        private IEnumerable<BankAccountDTO> LoadStorage()
        {
            var result = new List<BankAccountDTO>();
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
                        BankAccountTypesDTO bankAccountType = (BankAccountTypesDTO)currentBinaryReader.ReadInt32();
                        var bonusRate = currentBinaryReader.ReadInt32();
                        var loadedBankAccount = new BankAccountDTO(accountId, ownerFirstName, ownerLastName, ammount, bonus, isClosed, bankAccountType, bonusRate);
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

        public void Dispose()
        {
        }
    }
}