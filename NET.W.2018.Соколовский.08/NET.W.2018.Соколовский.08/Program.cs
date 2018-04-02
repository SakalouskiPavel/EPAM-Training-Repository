using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.W._2018.Соколовский._08.BusinessLogic.Services;
using NET.W._2018.Соколовский._08.Common;
using NET.W._2018.Соколовский._08.Common.Models;
using NET.W._2018.Соколовский._08.DataAccess.Repositories;

namespace NET.W._2018.Соколовский._08
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookStorage = new BookListStorage(@"H:\BookStorage.txt");
            var bookService = new BookListService(bookStorage);
            var newBook = new Book() {Author = "Author", Cost = 20, ISBN = "346632436562", Name = "Book name", PagesNumber = 246, PublicationYear = 2000, Publisher = "Publisher name"};
            Console.WriteLine(bookService.AddBook(newBook));
            var booksList = bookService.GetAllBooks();
            newBook = new Book() { Author = "Author2", Cost = 20, ISBN = "123632436562", Name = "Book name 2", PagesNumber = 246, PublicationYear = 2000, Publisher = "Publisher name 2" };
            Console.WriteLine(bookService.AddBook(newBook));
            booksList = bookService.SortBooksByTag(SearchTags.ISBN);
            var searchingResult = bookService.FindBooksByTag(SearchTags.ISBN, "123632436562");

            var bankAccountStorage = new BankAccountsRepository(@"H:\BankAccountStorage.txt");
            var bankAccountService = new BankAccountService(bankAccountStorage);
            var newBankAccount = new BankAccount(1, "FirstName", "LastName", 20, 0 ,false, BankAccountTypes.Standart, 10);
            Console.WriteLine(bankAccountService.AddAccount(newBankAccount));
            newBankAccount = new BankAccount(2, "FirstName2", "LastName2", 22, 3, false, BankAccountTypes.Gold, 20);
            Console.WriteLine(bankAccountService.AddAccount(newBankAccount));
            var bankAccountsList = bankAccountService.GetAllBankAccounts();
            bankAccountService.TopUpInAnAccount(30, (bankAccountsList.ToList())[0].AccountId);
            bankAccountService.DebitTheAccount(10, (bankAccountsList.ToList())[1].AccountId);

            Console.ReadKey();
        }
    }
}
