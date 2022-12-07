using Ardalis.ApiEndpoints;
using GameMissions.Core.GameAggregate;
using GameMissions.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.GameEndpoints;

public class Create : EndpointBaseAsync.WithRequest<CreateGameRequest>.WithActionResult<CreateGameResponse>
{
  private readonly IAddGameService _addGameService;

  public Create(IAddGameService addGameService) { _addGameService = addGameService; }

  [HttpPost("/Games")]
  [SwaggerOperation(
    Summary ="Creates a new Game",
    Description = "Creates a new Game",
    OperationId = "Game.Create",
    Tags = new[] {"GameEndpoints"})]
  public override async Task<ActionResult<CreateGameResponse>> HandleAsync(CreateGameRequest request, CancellationToken cancellationToken = new())
  {
    if(string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.PackageName))
    {
      return BadRequest();
    }

    var newGame = new Game(request.Title, request.PackageName, request.NextRewardedVideoTimeout,
      request.RewardedVideoReward, request.IntrestitialPerLevel, request.Description);
    
    newGame.Id = await _addGameService.AddGame(newGame);

    var response = new CreateGameResponse(newGame.Id);

    return Ok(response);
  }
}
