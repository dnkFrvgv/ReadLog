using api.Core.Interfaces;
using api.Models;
using MediatR;

namespace api.Authors
{
  public class GetAll
  {
    public class Query : IRequest<IEnumerable<Author>> { }

    public class Handler : IRequestHandler<Query, IEnumerable<Author>>
    {
      private readonly IUnitOfWork _unitOfWork;
      public Handler(IUnitOfWork unitOfWork)
      {
        _unitOfWork = unitOfWork;
      }
      public async Task<IEnumerable<Author>> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _unitOfWork.Authors.GetAll();
      }
    }
  }
}