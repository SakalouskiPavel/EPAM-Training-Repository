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
        /// <summary>
        /// Serialize url addresses to xml.
        /// </summary>
        /// <param name="urlAddresses"> List of url addresses.</param>
        /// <param name="path"> Path to xml file.</param>
        public void SaveToXml(UrlAdressesList urlAddresses, string path)
        {
            var serializer = new XmlSerializer(typeof(UrlAdressesList));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                    serializer.Serialize(stream, urlAddresses);
            }
        }
    }
}