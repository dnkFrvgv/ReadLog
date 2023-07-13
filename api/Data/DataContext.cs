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

      modelBuilder.Entity<Book>().HasMany(b => b.Reads).WithOne(l => l.Book).HasForeignKey(l => l.BookId);

      modelBuilder.Entity<Read>().HasMany(b => b.Logs).WithOne(l => l.Read).HasForeignKey(l => l.ReadId);

      modelBuilder.Entity<Read>().HasOne(b => b.Review).WithOne(r => r.Read).HasForeignKey<Review>(r => r.ReadId);
    }

    public DbSet<BookAuthor> BookAuthors;
    public DbSet<Author> Authors;
    public DbSet<Book> Books;
    public DbSet<Read> Reads;
    public DbSet<Log> Logs;
    public DbSet<Review> Reviews;
  }
}