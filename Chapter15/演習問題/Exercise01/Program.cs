using Section01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var book = Library.Books
                .First(x => x.Price == Library.Books.Max(y => y.Price));

            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            var books= Library.Books
                .GroupBy(x => x.PublishedYear)
                .Select(group => new {
                    Year = group.Key,
                    Count = group.Count()
                })
                .OrderBy(item => item.Year);

            foreach (var item in books) {
                Console.WriteLine($"発行年:{item.Year} 書籍の数:{item.Count}");
            }
        }

        private static void Exercise1_4() {
            var query = Library.Books
                .Join(Library.Categories,
                    Book => Book.CategoryId,
                    category => category.Id,
                    (book, category) => new {
                        book.Title,
                        book.PublishedYear,
                        book.Price,
                        CategoryName = category.Name,
                    }).OrderBy(x => x.PublishedYear)
                    .ThenByDescending(x => x.Price);

            foreach (var book in query) {
                Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title} ({book.CategoryName})");
            }
        }


        private static void Exercise1_5() {
            var names = Library.Books
                .Where(b => b.PublishedYear == 2016)
                .Join(Library.Categories,
                    book => book.CategoryId,
                    category => category.Id,
                    (book, category) => category.Name)
                .Distinct();
            foreach (var name in names) {
                Console.WriteLine(name);
            }

        }

        private static void Exercise1_6() {
        }

        private static void Exercise1_7() {
        }

        private static void Exercise1_8() {
        }
    }
}
