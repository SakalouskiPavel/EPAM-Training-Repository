using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using NET.W._2018.Соколовский._16.Interfaces;

namespace NET.W._2018.Соколовский._16.Services
{
    public class UrlAddressService : IUrlAddressService
    {
        private IUrlAddressesRepository _storage;

        public UrlAddressService(IUrlAddressesRepository storage)
        {
            this._storage = storage;
        }

        /// <summary>
        /// Gets url addresses list from storage.
        /// </summary>
        public List<Uri> UrlAddresses
        {
            get { return this._storage.GetAll().ToList(); }
        }

        /// <summary>
        /// Add url address to storage.
        /// </summary>
        /// <param name="url"> Url address as string.</param>
        public void Add(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            Uri addedUrlAddress = UrlAddressParserService.ConvertToUrl(url);

            if (!ReferenceEquals(addedUrlAddress, null))
            {
                this._storage.Add(addedUrlAddress);
            }
        }

        /// <summary>
        /// Delete url address from storage.
        /// </summary>
        /// <param name="url"> Url address as string.</param>
        public void Delete(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            Uri deletedUrlAddress = UrlAddressParserService.ConvertToUrl(url);
            this._storage.Delete(deletedUrlAddress);
        }
    }
}