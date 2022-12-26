using Ardalis.ApiEndpoints;
using GameMissions.Core.PlayerAggregate;
using GameMissions.Core.PlayerAggregate.Specifications;
using GameMissions.SharedKernel.Interfaces;
using GameMissions.Web.Endpoints.GameEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class Update : EndpointBaseAsync.WithRequest<UpdatePlayerRequest>.WithActionResult<UpdatePlayerResponse>
{
  private readonly IRepository<Player> _playerRepository;

  public Update(IRepository<Player> playerRepository)
  {
    _playerRepository = playerRepository;
  }

  [HttpPut(UpdateGameRequest.Route)]
  [SwaggerOperation(
    Summary = "Updates a Player",
    Description = "Updates a Player",
    OperationId = "Player.Update",
    Tags = new[] { "PlayerEndpoints" })]
  public override async Task<ActionResult<UpdatePlayerResponse>> HandleAsync(UpdatePlayerRequest request, CancellationToken cancellationToken = new())
  {
    if (string.IsNullOrEmpty(request.DeviceId))
    {
      return BadRequest();  
    }

    var player = await _playerRepository.GetByIdAsync(new PlayerByPlayerIdSpec(request.Id), cancellationToken);

    if (player == null)
    {
      return NotFound();
    }

    player.UpdateLevel(request.Level);
    player.UpdateRated(request.Rated);
    player.UpdateLastAdWatch(request.LastAdWatch);
    player.UpdateLastConnectedIP(request.LastConnectedIP);
    player.UpdateLocaleCode(request.LocaleCode);

    await _playerRepository.UpdateAsync(player, cancellationToken);

    var response = new GetPlayerByIdResponse(new PlayerRecord(player.Id, player.DeviceId, player.GameId, player.Level,
      player.LastAdWatch, player.Rated, player.LastConnectedIP, player.LocaleCode));


    return Ok(response);

  }
}
