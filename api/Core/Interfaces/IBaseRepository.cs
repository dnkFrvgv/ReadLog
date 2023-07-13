using System.Linq.Expressions;

namespace api.Core.Interfaces
{
  public interface IRepository<T> where T: class
  {
    Task<T> Get(int id);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    Task<T> Create(T entity);
    void CreateRange(IEnumerable<T> entity);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
  }
}