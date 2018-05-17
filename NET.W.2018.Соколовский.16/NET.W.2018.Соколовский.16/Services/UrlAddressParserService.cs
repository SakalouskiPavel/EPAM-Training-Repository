using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using NET.W._2018.Соколовский._16.Interfaces;
using NET.W._2018.Соколовский._16.Logger;

namespace NET.W._2018.Соколовский._16.Services
{
    public static class UrlAddressParserService
    {
       
        private static ILogger _logger = new CustomLogger();

        /// <summary>
        /// Convert url address from string format to custom type UrlAddress.
        /// </summary>
        /// <param name="url"> Url address as string.</param>
        /// <returns></returns>
        public static Uri ConvertToUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            try
            {
                Uri uri = new Uri(url);
                return uri;
            }
            catch (UriFormatException e)
            {
                _logger.Log($"\"{url}\" isn't url address");
                return null;
            }
        }
    }
}