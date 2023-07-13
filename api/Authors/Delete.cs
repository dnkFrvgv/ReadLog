using api.Core.Interfaces;
using MediatR;

namespace api.Authors
{
  public class Delete
  {
    public class Command : IRequest<Unit>
    {
      public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Command, Unit>
    {
      private readonly IUnitOfWork _unitOfWork;
      public Handler(IUnitOfWork unitOfWork)
      {
        _unitOfWork = unitOfWork;
      }
      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var author = await _unitOfWork.Authors.Get(request.Id);
        _unitOfWork.Authors.Delete(author);
        await _unitOfWork.CommitChanges();
        return Unit.Value;
      }
    }
  }
}