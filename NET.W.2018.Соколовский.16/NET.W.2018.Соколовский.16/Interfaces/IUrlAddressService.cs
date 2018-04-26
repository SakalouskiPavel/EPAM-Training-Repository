using System.Collections.Generic;
using NET.W._2018.Соколовский._16.Entities;

namespace NET.W._2018.Соколовский._16.Interfaces
{
    public interface IUrlAddressService
    {
        UrlAdressesList UrlAddresses { get; }

        void Add(string url);

        void Delete(string url);
    }
}