using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
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
            kernel.Bind<IBankAccountsRepository>().To<BankAccountsStorage>().WithConstructorArgument(@"H:\BankAccountStorage.txt");
            kernel.Bind<IBankAccountService>().To<BankAccountService>();
        }
    }
}