using Ninject;
using Task1.Solution.Interfaces;

namespace Task1.Solution.DependecyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolve(this IKernel kernel)
        {
            kernel.Bind<IPasswordCheckerService>().To<PasswordCheckerService>();
            kernel.Bind<IRepository>().To<SqlRepository>();
        }
    }
}