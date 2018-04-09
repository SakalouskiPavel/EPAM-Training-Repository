using System;
using System.Collections.Generic;
using NET.W._2018.Соколовский._08.Common;
using NET.W._2018.Соколовский._08.Common.Interfaces.Repositories;
using NET.W._2018.Соколовский._08.Common.Interfaces.Services;
using NET.W._2018.Соколовский._08.Common.Models;

namespace NET.W._2018.Соколовский._08.BusinessLogic.Services
{
    public class BookListService : IBookService
    {
        private IBookRepository _storage;

        public BookListService(IBookRepository storage)
        {
            this._storage = storage;
        }

        public Book AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            return this._storage.Add(book);
        }

        public IEnumerable<Book> FindBooksByTag(SearchTags tag, string value)
        {
            return this._storage.FindByTag(tag, value);
        }

        public Book RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            return this._storage.Delete(book);
        }

        public Book RemoveBook(string isbn)
        {
            return this._storage.Delete(isbn);
        }

        public IEnumerable<Book> SortBooksByTag(SearchTags tag)
        {
            return this._storage.SortByTag(tag);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this._storage.GetAll();
        }
    }
}