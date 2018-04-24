using System.Collections.Generic;
using NET.W._2018.Соколовский._16.Entities;

namespace NET.W._2018.Соколовский._16.Interfaces
{
    public interface IUrlAddressesRepository
    {
        UrlAddress Add(UrlAddress urlAddress);

        UrlAddress Delete(UrlAddress urlAddress);

        IEnumerable<UrlAddress> GetAll();
    }
}