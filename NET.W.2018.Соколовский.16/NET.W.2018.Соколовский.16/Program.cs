using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.W._2018.Соколовский._16.DependencyResolver;
using NET.W._2018.Соколовский._16.Interfaces;
using NET.W._2018.Соколовский._16.Repositories;
using NET.W._2018.Соколовский._16.Services;
using Ninject;

namespace NET.W._2018.Соколовский._16
{
    public class Program
    {
        private static IKernel _kernel;

        static Program()
        {
            _kernel = new StandardKernel();
            _kernel.ConfigurateResolver();
        }

        public static void Main(string[] args)
        {
            List<string> urls = new List<string>();
            urls.Add(@"https://github.com/AnzhelikaKravchuk?tab=repositories");
            urls.Add(@"https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU");
            urls.Add(@"https://habrahabr.ru/company/it-grad/blog/341486/");
            urls.Add(@"urladdress");
            var service = _kernel.Get<IUrlAddressService>();
            foreach (string url in urls)
            {
                service.Add(url);
            }

            var xml = _kernel.Get<IXmlService>();
            string xmlPath = "xmlFile.xml";
            xml.SaveToXml(service.UrlAddresses, xmlPath);
        }
    }
}
