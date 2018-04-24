using System.Collections.Generic;
using System.Xml.Serialization;
using NET.W._2018.Соколовский._16.Entities;
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
        
        public IEnumerable<UrlAddress> UrlAddresses
        {
            get { return this._storage.GetAll(); }
        }

        public void Add(string url)
        {
            var addedUrlAddress = UrlAddressParserService.ConvertToUrl(url);
            this._storage.Add(addedUrlAddress);
        }

        public void Delete(string url)
        {
            var deletedUrlAddress = UrlAddressParserService.ConvertToUrl(url);
            this._storage.Delete(deletedUrlAddress);
        }
    }
}