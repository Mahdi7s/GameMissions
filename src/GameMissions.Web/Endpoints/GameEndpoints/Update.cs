using Ardalis.ApiEndpoints;
using GameMissions.Core.GameAggregate;
using GameMissions.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.GameEndpoints;

public class Update : EndpointBaseAsync.WithRequest<UpdateGameRequest>.WithActionResult<UpdateGameResponse>
{
  private readonly IUpdateGameService _updateGameService;

  public Update(IUpdateGameService updateGameService)
  {
    _updateGameService = updateGameService;
  }

  [HttpGet(UpdateGameRequest.Route)]
  [SwaggerOperation(
      Summary = "Updates a Game",
      Description = "Updates a Game",
      OperationId = "Games.Update",
      Tags = new[] { "GameEndpoints" })
  ]
  public override async Task<ActionResult<UpdateGameResponse>> HandleAsync(UpdateGameRequest request, CancellationToken cancellationToken = new())
  {
    if (string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.PackageName))
    {
      return BadRequest();
    }

    var gameToUpdate = new Game(request.Title, request.PackageName, request.NextRewardedVideoTimeout,
      request.RewardedVideoReward, request.IntrestitialPerLevel, request.Description);
    
    var result = await _updateGameService.UpdateGame(gameToUpdate);

    if(!result.IsSuccess)
    {
      return NotFound();
    }

    var response = new UpdateGameResponse(new GameRecord(gameToUpdate.Id, gameToUpdate.Title,
      gameToUpdate.PackageName, gameToUpdate.NextRewardedVideoTimeout, gameToUpdate.RewardedVideoReward,
      gameToUpdate.IntrestitialPerLevel, gameToUpdate.Description));

    return Ok(response);
  }
}
