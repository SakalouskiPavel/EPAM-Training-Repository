using System.Collections.Generic;
using NET.W._2018.Соколовский._08.Common.Models;

namespace NET.W._2018.Соколовский._08.Common.Interfaces.Services
{
    public interface IBookService
    {
        Book AddBook(Book book);

        Book RemoveBook(Book book);

        Book RemoveBook(string isbn);

        IEnumerable<Book> FindBooksByTag(SearchTags tag, string value);

        IEnumerable<Book> SortBooksByTag(SearchTags tag);
    }
}