using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorDetails> AuthorDetails { get; set; }
    }
}
