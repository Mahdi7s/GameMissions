using Ardalis.ApiEndpoints;
using GameMissions.Core.PlayerAggregate;
using GameMissions.Core.PlayerAggregate.Specifications;
using GameMissions.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class GetByDeviceAndGameId : EndpointBaseAsync.WithRequest<GetByDeviceAndGameIdRequest>.WithActionResult<GetByDeviceAndGameIdResponse>
{
  private readonly IReadRepository<Player> _playerRepository;

  public GetByDeviceAndGameId(IReadRepository<Player> playerRepository)
  {
    _playerRepository = playerRepository;
  }

  public override async Task<ActionResult<GetByDeviceAndGameIdResponse>> HandleAsync(GetByDeviceAndGameIdRequest request, CancellationToken cancellationToken = new())
  {
    var spec = new PlayerByDeviceAndGameId(request.DeviceId, request.GameId);
    var player = _playerRepository.FirstOrDefaultAsync(spec);
    if(player == null)
    {
      return NotFound();
    }

    var response = new GetPlayerByIdResponse(new PlayerRecord(player.Id, player.DeviceId, player.GameId, player.Level,
      player.LastAdWatch, player.Rated, player.LastConnectedIP, player.LocaleCode));


    return Ok(response);
  }
}
