using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace NET.W._2018.Соколовский._16.Entities
{
    [XmlRoot("urlAddress")]
    public class UrlAddress
    {
        [XmlElement("schema")]
        public string Schema { get; set; }

        [XmlElement("host")]
        public string Host { get; set; }

        [XmlArray("uri")]
        [XmlArrayItem("segment")]
        public List<string> Uri { get; set; }

        [XmlArray("parameters")]
        [XmlArrayItem("parameter")]
        public List<UrlParametr> Parametrs { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{Schema}://{Host}");
            if (!ReferenceEquals(Uri, null))
            {
                foreach (var segment in Uri)
                {
                    sb.Append($"/{segment}");
                }
            }

            if (!ReferenceEquals(Parametrs, null))
            {
                sb.Append("?");
                foreach (var parametr in Parametrs)
                {
                    sb.Append($"{parametr.Key}={parametr.Value}&");
                }

                sb.Remove(sb.Length - 2, 1);
            }

            return sb.ToString();
        }
    }
}