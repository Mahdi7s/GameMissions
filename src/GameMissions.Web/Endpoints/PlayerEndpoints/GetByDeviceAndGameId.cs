using Ardalis.ApiEndpoints;
using GameMissions.Core.PlayerAggregate;
using GameMissions.Core.PlayerAggregate.Specifications;
using GameMissions.SharedKernel.Interfaces;
using GameMissions.Web.Endpoints.ProjectEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class GetByDeviceAndGameId : EndpointBaseAsync.WithRequest<GetByDeviceAndGameIdRequest>.WithActionResult<GetByDeviceAndGameIdResponse>
{
  private readonly IReadRepository<Player> _playerRepository;

  public GetByDeviceAndGameId(IReadRepository<Player> playerRepository)
  {
    _playerRepository = playerRepository;
  }
  [HttpGet(GetByDeviceAndGameIdRequest.Route)]
  [SwaggerOperation(
  Summary = "Gets a single Player",
  Description = "Gets a single Player by Id",
  OperationId = "Players.GetById",
  Tags = new[] { "PlayerEndpoints" })]
  public override async Task<ActionResult<GetByDeviceAndGameIdResponse>> HandleAsync(GetByDeviceAndGameIdRequest request, CancellationToken cancellationToken = new())
  {
    var spec = new PlayerByDeviceAndGameId(request.DeviceId, request.GameId);
    var player = await _playerRepository.FirstOrDefaultAsync(spec);
    if(player == null)
    {
      return NotFound();
    }

    var response = new GetPlayerByIdResponse(new PlayerRecord(player.Id, player.DeviceId, player.GameId, player.Level,
      player.LastAdWatch, player.Rated, player.LastConnectedIP, player.LocaleCode));


    return Ok(response);
  }
}
