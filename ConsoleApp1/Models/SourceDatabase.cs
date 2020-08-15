using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
//https://ralms.net/ef5/entity%20framework%20core/many-to-many-efcore5/?fbclid=IwAR2nqwsr5OTPOWuI9cZmk8Raj5KvwOsuTCBP9r_2CNtYHehiq4eop6SuCQg
namespace ConsoleApp1.Models
{
    public sealed class SourceDatabase : DbContext
    {
        public DbSet<Author> Author { get; set; }
        //public DbSet<AuthorBook> AuthorBook { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ./dbase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(m =>
            {
                m.ToTable("autor");
                m.HasKey(c => c.Id);
                m.Property(c => c.Id)
                    .HasColumnName("id");
                m.Property(c => c.Name)
                    .HasMaxLength(200)
                    .IsRequired();
                m.HasMany(c => c.Books)
                    .WithMany(c => c.Authors)
                    .UsingEntity<AuthorBook>(
                        a => a.HasOne<Author>().WithMany(),
                        b => b.HasOne<Book>().WithMany()
                    );
            });

            modelBuilder.Entity<Book>(m =>
            {
                m.ToTable("book");
                m.HasKey(c => c.Id);
                m.Property(c => c.Id)
                    .HasColumnName("id");
                m.Property(c => c.Title)
                    .HasMaxLength(200)
                    .IsRequired();
                m.HasMany(c => c.Authors)
                    .WithMany(c => c.Books);
            });
        }
    }
}
