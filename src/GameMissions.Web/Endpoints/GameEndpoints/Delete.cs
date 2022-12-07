using Ardalis.ApiEndpoints;
using GameMissions.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.GameEndpoints;

public class Delete : EndpointBaseAsync.WithRequest<DeleteGameRequest>.WithoutResult
{
  private readonly IDeleteGameService _deleteGameService;

  public Delete(IDeleteGameService deleteGameService)
  {
    _deleteGameService = deleteGameService;
  }

  [HttpDelete(DeleteGameRequest.Route)]
  [SwaggerOperation(
      Summary = "Deletes a Game",
      Description = "Deletes a Game",
      OperationId = "Game.Delete",
      Tags = new[] { "GameEndpoints" })
    ]
  public override async Task<ActionResult> HandleAsync(DeleteGameRequest request, CancellationToken cancellationToken = new())
  {
    var result = await _deleteGameService.DeleteGame(request.GameId);
    if (result?.IsSuccess == true)
    {
      return NoContent();
    }
    return NotFound();
  }
}
