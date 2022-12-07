using Ardalis.ApiEndpoints;
using GameMissions.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Collections.Generic;

namespace GameMissions.Web.Endpoints.GameEndpoints;

public class List : EndpointBaseAsync.WithoutRequest.WithActionResult<GameListResponse>
{
  private readonly IGameSearchService _gameSearchService;

  public List(IGameSearchService gameSearchService)
  {
    _gameSearchService = gameSearchService;
  }

  [HttpGet("/Games")]
  [SwaggerOperation(
      Summary = "Gets a list of all Games",
      Description = "Gets a list of all Games",
      OperationId = "Game.List",
      Tags = new[] { "GameEndpoints" })
  ]
  public async override Task<ActionResult<GameListResponse>> HandleAsync(CancellationToken cancellationToken = default)
  {
    var games = await _gameSearchService.GetAllGamesAsync();
    if(!games.IsSuccess || games.Errors.Any() || games.Value.Count <= 0)
    {
      return NotFound();
    }

    var response = new GameListResponse
    {
      Games = games.Value.Select(g => new GameRecord(g.Id, g.Title, g.PackageName, g.NextRewardedVideoTimeout,
        g.RewardedVideoReward, g.IntrestitialPerLevel, g.Description)).ToList()
    };

    return Ok(response);
  }
}
