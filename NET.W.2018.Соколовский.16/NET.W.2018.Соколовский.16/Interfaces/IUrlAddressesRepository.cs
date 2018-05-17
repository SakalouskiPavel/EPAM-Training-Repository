using System;
using System.Collections.Generic;
using NET.W._2018.Соколовский._16.Entities;

namespace NET.W._2018.Соколовский._16.Interfaces
{
    public interface IUrlAddressesRepository
    {
        Uri Add(Uri urlAddress);

        Uri Delete(Uri urlAddress);

        IEnumerable<Uri> GetAll();
    }
}