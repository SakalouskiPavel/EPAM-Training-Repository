using System.Data.Entity.ModelConfiguration;
using DAL.Interface.DTO;

namespace DAL.Configurations
{
    public class BankAccountDTOConfiguration : EntityTypeConfiguration<BankAccountDTO>
    {
        public BankAccountDTOConfiguration()
        {
            this.HasKey(n => n.AccountId);
        }
    }
}