namespace api.Core.Interfaces
{
  public interface IUnitOfWork
  {
    IAuthorRepository Authors { get; }
    Task<int> CommitChanges();
  }
}