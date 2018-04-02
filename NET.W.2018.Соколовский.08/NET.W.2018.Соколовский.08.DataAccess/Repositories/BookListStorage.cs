using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NET.W._2018.Соколовский._08.Common;
using NET.W._2018.Соколовский._08.Common.Interfaces.Repositories;
using NET.W._2018.Соколовский._08.Common.Models;

namespace NET.W._2018.Соколовский._08.DataAccess.Repositories
{
    public class BookListStorage : IBookRepository
    {
        private string _storagePath;

        private IEnumerable<Book> _storage;

        public BookListStorage(string storagePath)
        {
            this._storagePath = storagePath;
            this._storage = this.LoadStorage();
        }

        public Book Get(string isbn)
        {
            return this._storage.FirstOrDefault((b) => b.ISBN == isbn);
        }

        public IEnumerable<Book> GetAll()
        {
            return this._storage.ToList();
        }

        public Book Add(Book book)
        {
            using (var currentFileStream = new FileStream(_storagePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                using (var currentBinaryWriter = new BinaryWriter(currentFileStream))
                {
                    currentBinaryWriter.Write(book.ISBN);
                    currentBinaryWriter.Write(book.Author);
                    currentBinaryWriter.Write(book.Cost);
                    currentBinaryWriter.Write(book.Name);
                    currentBinaryWriter.Write(book.PagesNumber);
                    currentBinaryWriter.Write(book.PublicationYear);
                    currentBinaryWriter.Write(book.Publisher);
                }
            }

            _storage = this.LoadStorage();

            return book;
        }

        public Book Delete(Book book)
        {
            this._storage = this._storage.Except(new List<Book>() { book });
            SaveStorage();
            return book;
        }

        public Book Delete(string isbn)
        {
            var currentBook = this._storage.FirstOrDefault((b) => b.ISBN == isbn);
            return Delete(currentBook);
        }

        public IEnumerable<Book> FindByTag(SearchTags tag, string value)
        {
            switch (tag)
            {
                case (SearchTags.Name):
                    {
                        return this._storage.Where((b) => b.Name == value);
                    }

                case (SearchTags.Author):
                    {
                        return this._storage.Where((b) => b.Author == value);
                    }

                case (SearchTags.Cost):
                    {
                        return this._storage.Where((b) => b.Cost == Convert.ToDecimal(value));
                    }

                case (SearchTags.ISBN):
                    {
                        return this._storage.Where((b) => b.ISBN == value);
                    }

                case (SearchTags.Publisher):
                    {
                        return this._storage.Where((b) => b.Publisher == value);
                    }

                case (SearchTags.PublishingYear):
                    {
                        return this._storage.Where((b) => b.PublicationYear == Convert.ToInt32(value));
                    }

                default:
                    {
                        throw new ArgumentException(nameof(tag));
                    }
            }
        }

        public IEnumerable<Book> SortByTag(SearchTags tag)
        {
            switch (tag)
            {
                case (SearchTags.Name):
                {
                    return this._storage.OrderBy((b) => b.Name);
                }

                case (SearchTags.Author):
                {
                    return this._storage.OrderBy((b) => b.Author);
                }

                case (SearchTags.Cost):
                {
                    return this._storage.OrderBy((b) => b.Cost);
                }

                case (SearchTags.ISBN):
                {
                    return this._storage.OrderBy((b) => b.ISBN);
                }

                case (SearchTags.Publisher):
                {
                    return this._storage.OrderBy((b) => b.Publisher);
                }

                case (SearchTags.PublishingYear):
                {
                    return this._storage.OrderBy((b) => b.PublicationYear);
                }

                default:
                {
                    throw new ArgumentException(nameof(tag));
                }
            }
        }

        private IEnumerable<Book> LoadStorage()
        {
            var result = new List<Book>();
            using (var currentFileStream = new FileStream(_storagePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (var currentBinaryReader = new BinaryReader(currentFileStream))
                {
                    while (currentBinaryReader.BaseStream.Position != currentBinaryReader.BaseStream.Length)
                    {
                        var loadedBook = new Book();
                        loadedBook.ISBN = currentBinaryReader.ReadString();
                        loadedBook.Author = currentBinaryReader.ReadString();
                        loadedBook.Cost = currentBinaryReader.ReadDecimal();
                        loadedBook.Name = currentBinaryReader.ReadString();
                        loadedBook.PagesNumber = currentBinaryReader.ReadInt32();
                        loadedBook.PublicationYear = currentBinaryReader.ReadInt32();
                        loadedBook.Publisher = currentBinaryReader.ReadString();

                        result.Add(loadedBook);
                    }
                }
            }

            return result;
        }

        private void SaveStorage()
        {
            using (var currentFileStream = new FileStream(_storagePath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (var currentBinaryWriter = new BinaryWriter(currentFileStream))
                {
                    foreach (var book in _storage)
                    {
                        currentBinaryWriter.Write(book.ISBN);
                        currentBinaryWriter.Write(book.Author);
                        currentBinaryWriter.Write(book.Cost);
                        currentBinaryWriter.Write(book.Name);
                        currentBinaryWriter.Write(book.PagesNumber);
                        currentBinaryWriter.Write(book.PublicationYear);
                        currentBinaryWriter.Write(book.Publisher);
                    }
                }
            }
        }
    }
}