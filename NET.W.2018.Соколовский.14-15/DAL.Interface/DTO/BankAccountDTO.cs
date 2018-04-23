using DAL.Interface.Enums;

namespace DAL.Interface.DTO
{
    public class BankAccountDTO
    {
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

        public int AccountId { get; }

        public string OwnerFirstName { get; }

        public string OwnerLastName { get; }

        public decimal Ammount { get; set; }

        public int Bonus { get; set; }

        public bool IsClosed { get; set; }

        public BankAccountTypesDTO BankAccountType { get; }

        public int BonusRate { get; }
    }
}