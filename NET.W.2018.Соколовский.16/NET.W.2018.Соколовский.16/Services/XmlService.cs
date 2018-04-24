using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using NET.W._2018.Соколовский._16.Entities;
using NET.W._2018.Соколовский._16.Interfaces;

namespace NET.W._2018.Соколовский._16.Services
{
    public class XmlService : IXmlService
    {
        public void SaveToXml(IEnumerable<UrlAddress> urlAddresses, string path)
        {
            var serializer = new XmlSerializer(typeof(UrlAddress));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                foreach (UrlAddress urlAddress in urlAddresses)
                {
                    serializer.Serialize(stream, urlAddress);
                }
            }
        }
    }
}