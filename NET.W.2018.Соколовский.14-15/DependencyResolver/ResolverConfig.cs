using System.Data.Entity;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Context;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolve(this IKernel kernel)
        {
            // kernel.Bind<IRepository>().To<Repository>();
            kernel.Bind<IBankAccountsRepository>().To<SqlBankAccountsStorage>();
            kernel.Bind<IBankAccountService>().To<BankAccountService>();
            kernel.Bind<CustomContext>().ToSelf();
            kernel.Bind<DbContext>().To<CustomContext>();
        }
    }
}