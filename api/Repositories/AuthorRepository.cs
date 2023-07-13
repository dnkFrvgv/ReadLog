using api.Core.Interfaces;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
  public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
  {
    public AuthorRepository(DataContext context) : base(context) { }
    public async Task<IEnumerable<Author>> GetAuthorsWithBooks()
    {
      return await _context.Authors.Include(a => a.Books).ToListAsync();
    }
    public async Task<Author> GetAuthorWithBooks(int id)
    {
      return await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
    }
  }
}