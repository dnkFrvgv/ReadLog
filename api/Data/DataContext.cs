using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookId, ba.AuthorId });

      modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Book).WithMany(ba => ba.Authors).HasForeignKey(ba => ba.BookId);
      modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Author).WithMany(ba => ba.Books).HasForeignKey(ba => ba.AuthorId);

      modelBuilder.Entity<Book>().HasMany(b => b.Logs).WithOne(l => l.Book).HasForeignKey(l => l.BookId);

      modelBuilder.Entity<Book>().HasOne(b => b.Review).WithOne(r => r.Book).HasForeignKey<Review>(r => r.BookId);
    }

    DbSet<BookAuthor> BookAuthors;
    DbSet<Author> Authors;
    DbSet<Book> Books;
    DbSet<Log> Logs;
    DbSet<Review> Reviews;
  }
}