using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.W._2018.Соколовский._16.Repositories;
using NET.W._2018.Соколовский._16.Services;

namespace NET.W._2018.Соколовский._16
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "repo.txt";
            List<string> urls = new List<string>();
            urls.Add(@"https://github.com/AnzhelikaKravchuk?tab=repositories");
            urls.Add(@"https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU");
            urls.Add(@"https://habrahabr.ru/company/it-grad/blog/341486/");
            var storage = new UrlAddressRepository(path);
            var service = new UrlAddressService(storage);
            foreach (string url in urls)
            {
                service.Add(url);
            }

            var xml = new XmlService();
            string xmlPath = "xmlFile.xml";
            xml.SaveToXml(service.UrlAddresses, xmlPath);
        }
    }
}
