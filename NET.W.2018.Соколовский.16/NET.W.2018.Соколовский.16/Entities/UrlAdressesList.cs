using System.Collections.Generic;
using System.Xml.Serialization;

namespace NET.W._2018.Соколовский._16.Entities
{
    [XmlRoot("root")]
    public class UrlAdressesList
    {
        [XmlArray("urlAddresses")]
        [XmlArrayItem("urlAddress")]
        public List<UrlAddress> UrlAddresses { get; set; }
    }
}