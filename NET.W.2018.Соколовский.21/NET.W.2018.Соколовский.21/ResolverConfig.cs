using System.Data.Entity;
using Ninject;

namespace NET.W._2018.Соколовский._21
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolve(this IKernel kernel)
        {
            kernel.Bind<IBankAccount>().To<BankAccount>();
            kernel.Bind<CustomContext>().ToSelf();
            kernel.Bind<Logger>().ToSelf();
        }
    }
}