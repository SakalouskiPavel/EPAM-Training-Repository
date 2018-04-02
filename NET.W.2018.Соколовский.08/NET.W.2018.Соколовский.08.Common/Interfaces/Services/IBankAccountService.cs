using NET.W._2018.Соколовский._08.Common.Models;

namespace NET.W._2018.Соколовский._08.Common.Interfaces.Services
{
    public interface IBankAccountService
    {
        BankAccount TopUpInAnAccount(decimal amount, int accountId);

        BankAccount DebitTheAccount(decimal amount, int accountId);

        BankAccount AddAccount(BankAccount bankAccount);

        BankAccount RemoveAccount(BankAccount bankAccount);

        BankAccount CloseAnAccount(int accountId);
    }
}