using BLL.Interface.Entities;
using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    public interface IBankAccountsRepository
    {
        BankAccount Get(int accountId);

        BankAccount Add(BankAccount bankAccount);

        BankAccount Update(BankAccount bankAccount);

        BankAccount Delete(BankAccount bankAccount);

        IEnumerable<BankAccount> GetAll();
    }
}
