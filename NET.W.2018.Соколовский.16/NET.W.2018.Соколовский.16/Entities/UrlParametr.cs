using System.Xml.Serialization;

namespace NET.W._2018.Соколовский._16.Entities
{
    [XmlRoot("parametr")]
    public class UrlParametr
    {
        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}