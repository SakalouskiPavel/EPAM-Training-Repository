using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
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
        public void SaveToXml(List<Uri> urlAddresses, string path)
        {
            XDocument xdoc = new XDocument();
            XElement urlAddressesElement = new XElement("urlAddresses");
            foreach (Uri urlAddress in urlAddresses)
            {
                XElement url = new XElement("urlAddress");
                XElement scheme = new XElement("scheme", urlAddress.Scheme);
                XElement host = new XElement("host", urlAddress.Host);
                url.Add(scheme);
                url.Add(host);

                if (urlAddress.Segments.Length > 0)
                {
                    XElement segments = new XElement("segments");
                    foreach (var segment in urlAddress.Segments)
                    {
                        if (segment.Replace("/", "").Length > 0)
                        {
                            XElement segmentElement = new XElement("segment", segment.Replace("/", ""));
                            segments.Add(segmentElement);
                        }
                    }

                    url.Add(segments);
                }

                if (!string.IsNullOrEmpty(urlAddress.Query))
                {
                    XElement parameters = new XElement("parameters");
                    var query = urlAddress.Query.Replace("?", "");
                    var parametrsList = query.Split('&');
                    foreach (string s in parametrsList)
                    {
                        var keyValuePair = s.Split('=');
                        XAttribute keyAttribute = new XAttribute("key", keyValuePair[0]);
                        XAttribute valuAttribute = new XAttribute("value", keyValuePair[1]);
                        XElement parameterElement = new XElement("parameter");
                        parameterElement.Add(keyAttribute);
                        parameterElement.Add(valuAttribute);
                        parameters.Add(parameterElement);
                    }

                    url.Add(parameters);
                }

                urlAddressesElement.Add(url);
            }

            xdoc.Add(urlAddressesElement);
            xdoc.Save(path);
        }
    }
}