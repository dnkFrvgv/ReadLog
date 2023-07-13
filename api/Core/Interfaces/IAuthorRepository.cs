using api.Models;

namespace api.Core.Interfaces
{
  public interface IAuthorRepository : IRepository<Author>
  {
    Task<IEnumerable<Author>> GetAuthorsWithBooks();
    Task<Author> GetAuthorWithBooks(int id);
  }
}