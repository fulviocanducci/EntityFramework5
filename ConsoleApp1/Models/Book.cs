using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public class Book
    {
        public Book()
        {
            Authors = new List<Author>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public IList<Author> Authors { get; set; }
    }
}
