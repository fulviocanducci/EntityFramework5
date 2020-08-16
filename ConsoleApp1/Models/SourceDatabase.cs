using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
//https://ralms.net/ef5/entity%20framework%20core/many-to-many-efcore5/?fbclid=IwAR2nqwsr5OTPOWuI9cZmk8Raj5KvwOsuTCBP9r_2CNtYHehiq4eop6SuCQg
namespace ConsoleApp1.Models
{
    public sealed class SourceDatabase : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/Developer/source/repos/dbase.db")
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
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
                    .WithMany(c => c.Authors);
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
                    .WithMany(c => c.Books).;
            });
        }
    }
}
