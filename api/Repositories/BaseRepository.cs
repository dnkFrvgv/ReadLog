using System.Linq.Expressions;
using api.Core.Interfaces;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
  public class BaseRepository<T> : IRepository<T> where T : class
  {
    protected readonly DataContext _context;
    public BaseRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<T> Create(T entity)
    {
      await _context.Set<T>().AddAsync(entity);
      return entity;
    }

    public async void CreateRange(IEnumerable<T> entity)
    {
      await _context.Set<T>().AddRangeAsync(entity);
    }

    public void Delete(T entity)
    {
      _context.Set<T>().Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
      _context.Set<T>().RemoveRange(entities);
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
    {
      var entities = _context.Set<T>().Where(expression);
      return await entities.ToListAsync();  
    }

    public async Task<T> Get(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
      return await _context.Set<T>().ToListAsync();
    }
  }
}