using System.Collections.Generic;
using NET.W._2018.Соколовский._08.Common.Models;

namespace NET.W._2018.Соколовский._08.Common.Interfaces.Repositories
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