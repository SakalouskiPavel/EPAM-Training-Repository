using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IBankAccountsRepository
    {
        BankAccountDTO Get(int accountId);

        BankAccountDTO Add(BankAccountDTO bankAccount);

        BankAccountDTO Update(BankAccountDTO bankAccount);

        BankAccountDTO Delete(BankAccountDTO bankAccount);

        IEnumerable<BankAccountDTO> GetAll();
    }
}
