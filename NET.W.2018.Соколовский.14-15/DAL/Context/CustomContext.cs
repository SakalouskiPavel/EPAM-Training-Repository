using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using DAL.Configurations;
using DAL.Interface.DTO;

namespace DAL.Context
{
    public class CustomContext : DbContext
    {
        public CustomContext() : base("BankAccountsDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomContext>());
        }

        public DbSet<BankAccountDTO> BankAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BankAccountDTOConfiguration());
        }
    }
}