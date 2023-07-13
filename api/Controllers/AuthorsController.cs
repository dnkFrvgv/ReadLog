using api.Authors;
using api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  public class AuthorsController : ApiBaseController
  {
    private readonly IMediator _mediator;
    public AuthorsController(IMediator mediator)
    {
      _mediator = mediator;
    }
    [HttpGet]
    public async Task<IEnumerable<Author>> GetAuthors()
    {
      return await _mediator.Send(new GetAll.Query());
    }
    [HttpGet("{id}")]
    public async Task<Author> GetAuthorById(int id)
    {
      return await _mediator.Send(new Get.Query { Id = id });
    }
    [HttpPost]
    public async Task<Author> CreateAuthor(string name)
    {
      return await _mediator.Send(new CreateAuthor.Command { Name = name });
    }

    [HttpDelete("{id}")]
    public async Task<Unit> DeleteAuthor(int id)
    {
      return await _mediator.Send(new Delete.Command { Id = id });
    }
  }
}