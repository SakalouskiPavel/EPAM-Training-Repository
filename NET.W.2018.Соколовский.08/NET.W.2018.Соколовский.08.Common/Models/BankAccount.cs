namespace NET.W._2018.Соколовский._08.Common.Models
{
    public class BankAccount
    {
        public BankAccount(int accountId, string ownerFirstName, string ownerLastName, decimal ammount, int bonus, bool isClosed, BankAccountTypes bankAccountType, int bonusRate)
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

        public BankAccountTypes BankAccountType { get;  }

        public int BonusRate { get; }
    }
}