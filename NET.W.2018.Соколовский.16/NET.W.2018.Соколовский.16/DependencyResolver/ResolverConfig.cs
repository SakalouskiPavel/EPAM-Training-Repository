using NET.W._2018.Соколовский._16.Interfaces;
using NET.W._2018.Соколовский._16.Logger;
using NET.W._2018.Соколовский._16.Repositories;
using NET.W._2018.Соколовский._16.Services;
using Ninject;

namespace NET.W._2018.Соколовский._16.DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IUrlAddressService>().To<UrlAddressService>();
            kernel.Bind<IUrlAddressesRepository>().To<UrlAddressRepository>().WithConstructorArgument("repo.txt");
            kernel.Bind<IXmlService>().To<XmlService>();
            kernel.Bind<ILogger>().To<CustomLogger>();
        }
    }
}