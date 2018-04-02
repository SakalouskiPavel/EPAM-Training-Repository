using System;
using System.Text;

namespace NET.W._2018.Соколовский._08.Common.Models
{
    public class Book : IComparable
    {
        public string ISBN { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public int PublicationYear { get; set; }

        public int PagesNumber { get; set; }

        public decimal Cost { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return this.CheckAllProperties(this, obj as Book);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (!(obj is Book))
            {
                throw new ArgumentException(nameof(obj));
            }

            var comparebleBook = obj as Book;

            if (string.Compare(ISBN, comparebleBook.ISBN) != 0)
            {
                return string.Compare(ISBN, comparebleBook.ISBN);
            }

            if (string.Compare(Author, comparebleBook.Author) != 0)
            {
                return string.Compare(Author, comparebleBook.Author);
            }

            if (string.Compare(Name, comparebleBook.Name) != 0)
            {
                return string.Compare(Name, comparebleBook.Name);
            }

            if (string.Compare(Publisher, comparebleBook.Publisher) != 0)
            {
                return string.Compare(Publisher, comparebleBook.Publisher);
            }

            if (PublicationYear.CompareTo(comparebleBook.PublicationYear) != 0)
            {
                return PublicationYear.CompareTo(comparebleBook.PublicationYear);
            }

            if (PagesNumber.CompareTo(comparebleBook.PagesNumber) != 0)
            {
                return PagesNumber.CompareTo(comparebleBook.PagesNumber);
            }

            if (Cost.CompareTo(comparebleBook.Cost) != 0)
            {
                return Cost.CompareTo(comparebleBook.Cost);
            }

            return 0;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(this.Author);
            result.Append(" ");
            result.Append(this.Name);
            return result.ToString();
        }

        private bool CheckAllProperties(Book first, Book second)
        {
            if (first.ISBN != second.ISBN)
            {
                return false;
            }

            if (first.Author != second.Author)
            {
                return false;
            }

            if (first.Cost != second.Cost)
            {
                return false;
            }

            if (first.Name != second.Name)
            {
                return false;
            }

            if (first.PagesNumber != second.PagesNumber)
            {
                return false;
            }

            if (first.PublicationYear != second.PublicationYear)
            {
                return false;
            }

            if (first.Publisher != second.Publisher)
            {
                return false;
            }

            return true;
        }

    }
}
