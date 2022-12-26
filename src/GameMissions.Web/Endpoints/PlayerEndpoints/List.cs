using System.Numerics;
using Ardalis.ApiEndpoints;
using GameMissions.Core.PlayerAggregate;
using GameMissions.SharedKernel.Interfaces;
using GameMissions.Web.Endpoints.MissionEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class List : EndpointBaseAsync.WithoutRequest.WithActionResult<PlayerListResponse>
{
  private readonly IReadRepository<Player> _playerRepository;

  public List(IReadRepository<Player> playerRepository)
  {
    _playerRepository = playerRepository;
  }

  [HttpGet("/Players")]
  [SwaggerOperation(
    Summary = "Gets all Players",
    Description = "Gets all Players",
    OperationId = "Players.GetById",
    Tags = new[] { "PlayerEndpoints" })]
  public override async Task<ActionResult<PlayerListResponse>> HandleAsync(CancellationToken cancellationToken = new())
  {
    var allPlayers = await _playerRepository.ListAsync(cancellationToken);

    if (!allPlayers.Any())
    {
      return NotFound();
    }

    var response = new PlayerListResponse
    {
      Players = allPlayers.Select(p => new PlayerRecord(p.Id, p.DeviceId, p.GameId,
      p.Level, p.LastAdWatch, p.Rated, p.LastConnectedIP, p.LocaleCode)).ToList()
    };

    return Ok(response);
  }
}
