using api.Core.Interfaces;
using api.Models;
using MediatR;

namespace api.Authors
{
  public class CreateAuthor
  {
    public class Command : IRequest<Author>
    {
      public string Name { get; set; }
    }

    public class Handler : IRequestHandler<Command, Author>
    {
      private readonly IUnitOfWork _unitOfWork;
      public Handler(IUnitOfWork unitOfWork)
      {
        _unitOfWork = unitOfWork;
      }
      public async Task<Author> Handle(Command request, CancellationToken cancellationToken)
      {
        var author = new Author(){Name=request.Name};

        author = await _unitOfWork.Authors.Create(author);
        await _unitOfWork.CommitChanges();
        return author;
      }
    }
  }


}