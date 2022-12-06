using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameMissions.Web.Controllers;
[Route("[controller]")]
public class GameController : Controller
{
  private readonly IMediator _mediator;

  public GameController(IMediator mediator)
  {
    _mediator = mediator;
  }

  //public async IActionResult Index()
  //{
  //  await _mediator.Send()
  //}
}
