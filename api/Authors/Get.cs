using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Core.Interfaces;
using api.Models;
using MediatR;

namespace api.Authors
{
  public class Get
  {
    public class Query : IRequest<Author>
    {
      public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Author>
    {
      private readonly IUnitOfWork _unitOfWork;
      public Handler(IUnitOfWork unitOfWork)
      {
        _unitOfWork = unitOfWork;
      }
      public async Task<Author> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _unitOfWork.Authors.Get(request.Id);
      }
    }
  }
}