using System;
using System.Collections.Generic;
using System.IO;
using NET.W._2018.Соколовский._16.Entities;
using NET.W._2018.Соколовский._16.Interfaces;
using NET.W._2018.Соколовский._16.Services;

namespace NET.W._2018.Соколовский._16.Repositories
{
    public class UrlAddressRepository : IUrlAddressesRepository
    {
        private readonly string _storagePath;

        private List<UrlAddress> _urlAddresses;

        public UrlAddressRepository(string storagePath)
        {
            this._storagePath = storagePath;
            LoadStorage();
        }

        public UrlAddress Add(UrlAddress urlAddress)
        {
            if (ReferenceEquals(urlAddress, null))
            {
                throw new ArgumentNullException(nameof(urlAddress));
            }

            this._urlAddresses.Add(urlAddress);
            SaveStorage();
            return urlAddress;
        }

        public UrlAddress Delete(UrlAddress urlAddress)
        {
            if (ReferenceEquals(urlAddress, null))
            {
                throw new ArgumentNullException(nameof(urlAddress));
            }

            this._urlAddresses.Remove(urlAddress);
            SaveStorage();
            return urlAddress;
        }

        public IEnumerable<UrlAddress> GetAll()
        {
            return this._urlAddresses;
        }

        private void LoadStorage()
        {
            var result = new List<UrlAddress>();
            using (var currentFileStream = new FileStream(this._storagePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (var currentBinaryReader = new BinaryReader(currentFileStream))
                {
                    while (currentBinaryReader.BaseStream.Position != currentBinaryReader.BaseStream.Length)
                    {
                        var stringUrl = currentBinaryReader.ReadString();
                        result.Add(UrlAddressParserService.ConvertToUrl(stringUrl));
                    }
                }
            }

            this._urlAddresses = result;
        }

        private void SaveStorage()
        {
            using (var currentFileStream = new FileStream(this._storagePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                using (var currentBinaryWriter = new BinaryWriter(currentFileStream))
                {
                    foreach (var url in this._urlAddresses)
                    {
                        currentBinaryWriter.Write(url.ToString());
                    }
                }
            }
        }
    }
}