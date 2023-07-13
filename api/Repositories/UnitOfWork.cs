using api.Core.Interfaces;
using api.Repositories;
using api.Data;

namespace api.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DataContext _context;
    public UnitOfWork(DataContext context)
    {
      _context = context;
      Authors = new AuthorRepository(_context);
    }
    public IAuthorRepository Authors { get; private set; }

    public async Task<int> CommitChanges()
    {
      return await _context.SaveChangesAsync();
    }
  }
}