using System.Collections.Generic;
using NET.W._2018.Соколовский._08.Common.Models;

namespace NET.W._2018.Соколовский._08.Common.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Book Get(string isbn);

        IEnumerable<Book> GetAll();

        Book Add(Book book);

        Book Delete(Book book);

        Book Delete(string isbn);

        IEnumerable<Book> FindByTag(SearchTags tag, string value);

        IEnumerable<Book> SortByTag(SearchTags tag);
    }
}