using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SourceDatabase source = new SourceDatabase())
            {
                //source.Database.EnsureDeleted();
                //source.Database.EnsureCreated();

                //Author author = new Author
                //{
                //    Name = "Peter Son"
                //};
                //Book book0 = new Book
                //{
                //    Title = "Girls"
                //};
                //Book book1 = new Book
                //{
                //    Title = "Shopping"
                //};

                //source.Author.Add(author);
                //source.Book.Add(book0);
                //source.Book.Add(book1);

                //source.SaveChanges();

                //author.Books.Add(book0);
                //author.Books.Add(book1);

                //source.SaveChanges();

                var lista = source.Author.Select(c => new { c.Id, Name = c.Name.ToUpper() }).ToList();
            }

            Console.WriteLine("Done ...");
        }
    }
}
