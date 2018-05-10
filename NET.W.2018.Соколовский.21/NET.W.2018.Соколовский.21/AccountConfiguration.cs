using System.Data.Entity.ModelConfiguration;

namespace NET.W._2018.Соколовский._21
{
    public class AccountConfiguration : EntityTypeConfiguration<BankAccount>
    {
        public AccountConfiguration()
        {
            this.HasKey(n => n.AccountId);
        }
    }
}