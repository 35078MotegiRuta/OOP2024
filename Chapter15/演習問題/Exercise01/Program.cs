using Section01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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
            var query = Library.Books
                .Join(Library.Categories,
                    book => book.CategoryId,
                    category => category.Id,
                    (book, category) => new {
                        book.Title,
                        categoryName = category.Name,
                    })
                .GroupBy(x => x.categoryName)
                .OrderBy(x => x.Key);
            foreach (var group in query) {
                Console.WriteLine($"#{group.Key}");
                foreach (var item in group) {
                    Console.WriteLine($" {item.Title}");
                }
            }
        }

        private static void Exercise1_7() {
            var categoriesId = Library.Categories.Single(c => c.Name == "Development").Id;
            var query = Library.Books.Where(b => b.CategoryId == categoriesId)
                                        .GroupBy(b => b.PublishedYear)
                                        .OrderBy(b => b.Key);
            foreach (var group in query) {
                Console.WriteLine($"#{group.Key}");
                foreach (var item in group) {
                    Console.WriteLine($" {item.Title}");
                }
            }
        }

        private static void Exercise1_8() {
            var query = Library.Categories
                            .GroupJoin(Library.Books,
                                        c => c.Id,
                                        b => b.CategoryId,
                                        (c, b) => new {
                                            categoryName = c.Name,
                                            count = b.Count()
                                        })
                                        .Where(x => x.count >= 4);

            foreach (var group in query) {
                Console.WriteLine(group.categoryName + "(" + group.count + ")");
            }
        }
    }
}
