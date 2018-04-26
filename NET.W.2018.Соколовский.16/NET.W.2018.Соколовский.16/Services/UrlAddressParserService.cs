using System.Collections.Generic;
using System.Text.RegularExpressions;
using NET.W._2018.Соколовский._16.Entities;
using NET.W._2018.Соколовский._16.Interfaces;
using NET.W._2018.Соколовский._16.Logger;

namespace NET.W._2018.Соколовский._16.Services
{
    public static class UrlAddressParserService
    {
        private const string _schemaPattern = @"http|https";
        private const string _hostPattern = @"[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}";
        private const string _segmentPattern = @"[a-zA-Z0-9\-\.]+";
        private const string _parameterPattern = @"([a-zA-Z0-9\-\.]+)=([a-zA-Z0-9\-\.]+)";
        private static string _urlPattern = $@"^({_schemaPattern})\://({_hostPattern})((/{_segmentPattern})+)?(\?{_parameterPattern}(&{_parameterPattern})*)?/?$";
        private static ILogger _logger = new CustomLogger();

        /// <summary>
        /// Convert url address from string format to custom type UrlAddress.
        /// </summary>
        /// <param name="url"> Url address as string.</param>
        /// <returns></returns>
        public static UrlAddress ConvertToUrl(string url)
        {
            if (Regex.IsMatch(url, _urlPattern))
            {
                var newUrlAddress = new UrlAddress();
                Match urlMatch = Regex.Match(url, _urlPattern);

                newUrlAddress.Schema = urlMatch.Groups[1].Value;
                newUrlAddress.Host = urlMatch.Groups[2].Value;

                if (!string.IsNullOrEmpty(urlMatch.Groups[3].Value))
                {
                    var matches = Regex.Matches(urlMatch.Groups[3].Value, _segmentPattern);
                    newUrlAddress.Uri = new List<string>();
                    foreach (Match match in matches)
                    {
                        newUrlAddress.Uri.Add(match.Value);
                    }
                }

                if (!string.IsNullOrEmpty(urlMatch.Groups[5].Value))
                {
                    var matches = Regex.Matches(urlMatch.Groups[5].Value, _parameterPattern);
                    newUrlAddress.Parameters = new List<UrlParameter>();

                    foreach (Match match in matches)
                    {
                        newUrlAddress.Parameters.Add(new UrlParameter(){ Key = match.Groups[1].Value, Value = match.Groups[2].Value});
                    }
                }

                return newUrlAddress;
            }

            _logger.Log($"\"{url}\" isn't url address");
            return null;
        }
    }
}