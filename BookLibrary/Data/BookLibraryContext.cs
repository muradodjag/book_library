using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BookLibrary.Data
{
    public class BookLibraryContext : DbContext
    {
        public BookLibraryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<BookGenre>()
           //  .HasKey(g => new { g.BookId, g.GenreId });

           // modelBuilder.Entity<BookGenre>()
           //     .HasOne(bg => bg.Book)
           //     .WithMany(b => b.BookGenres)
           //     .HasForeignKey(bg => bg.BookId);

           // modelBuilder.Entity<BookGenre>()
           //     .HasOne(bg => bg.Genre)
           //     .WithMany(g => g.BookGenres)
           //     .HasForeignKey(bg => bg.GenreId);

           // modelBuilder.Entity<BookAuthor>()
           //.HasKey(a => new { a.BookId, a.AuthorId });

           // modelBuilder.Entity<BookAuthor>()
           //     .HasOne(ba => ba.Book)
           //     .WithMany(b => b.BookAuthors)
           //     .HasForeignKey(ba => ba.BookId);

           // modelBuilder.Entity<BookAuthor>()
           //     .HasOne(ba => ba.Author)
           //     .WithMany(g => g.BookAuthors)
           //     .HasForeignKey(ba => ba.AuthorId);
        }

    }
}
