﻿using System.Collections.Generic;
using NET.W._2018.Соколовский._16.Entities;

namespace NET.W._2018.Соколовский._16.Interfaces
{
    public interface IXmlService
    {
        void SaveToXml(IEnumerable<UrlAddress> urlAddresses, string path);
    }
}