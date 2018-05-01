using System.Security.Permissions;
using DAL.Interface.Enums;

namespace DAL.Interface.DTO
{
    public class BankAccountDTO
    {
        public BankAccountDTO()
        {
            
        }

        public BankAccountDTO(int accountId, string ownerFirstName, string ownerLastName, decimal ammount, int bonus, bool isClosed, BankAccountTypesDTO bankAccountType, int bonusRate)
        {
            AccountId = accountId;
            OwnerFirstName = ownerFirstName;
            OwnerLastName = ownerLastName;
            Ammount = ammount;
            Bonus = bonus;
            IsClosed = isClosed;
            BankAccountType = bankAccountType;
            BonusRate = bonusRate;
        }
        
        public int AccountId { get; set; }

        public string OwnerFirstName { get; set; }

        public string OwnerLastName { get; set; }

        public decimal Ammount { get; set; }

        public int Bonus { get; set; }

        public bool IsClosed { get; set; }

        public BankAccountTypesDTO BankAccountType { get; set; }

        public int BonusRate { get; set; }
    }
}