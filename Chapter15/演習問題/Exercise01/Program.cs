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
            var books = Library.Books
                .OrderByDescending(x => x.PublishedYear)
                .ThenByDescending(x => x.Price)
                .Select(x => new {
                    x.Title,
                    x.PublishedYear,
                    x.Price,
                });

            foreach (var book in books) {
                Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title}");
            }
        }


        private static void Exercise1_5() {
        }

        private static void Exercise1_6() {
        }

        private static void Exercise1_7() {
        }

        private static void Exercise1_8() {
        }
    }
}
