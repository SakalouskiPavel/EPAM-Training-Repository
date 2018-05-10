using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2018.Соколовский._21
{
    public class CustomContext : DbContext
    {
        public CustomContext() : base("BankAccounts")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomContext>());
        }

        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AccountConfiguration());
        }
    }
}

