using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerHomework.Models
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext()
        {
        }

        public BooksDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId);

            modelBuilder.Entity<AuthorDetails>()
                .Property(a => a.Sex)
                .HasConversion<string>();

            modelBuilder.Entity<Author>()
                .HasOne(a => a.AuthorDetails)
                .WithOne(a => a.Author)
                .HasForeignKey<AuthorDetails>(a => a.AuthorId);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .UsingEntity(a => a.ToTable("AuthorsBooks"));
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorDetails> AuthorDetails { get; set; }
    }
}
