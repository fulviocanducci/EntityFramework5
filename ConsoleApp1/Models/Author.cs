using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Book> Books { get; set; }
    }
}
