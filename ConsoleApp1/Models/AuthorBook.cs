using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models
{
    [Keyless()]
    public class AuthorBook
    {
        public int AuthorId { get; set; }
        //public Author Author { get; set; }

        public int BookId { get; set; }
        //public Book Book { get; set; }
    }
}
