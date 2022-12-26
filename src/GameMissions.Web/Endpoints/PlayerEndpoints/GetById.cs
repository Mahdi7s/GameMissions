using Ardalis.ApiEndpoints;
using GameMissions.Core.PlayerAggregate;
using GameMissions.Core.PlayerAggregate.Specifications;
using GameMissions.SharedKernel.Interfaces;
using GameMissions.Web.Endpoints.ProjectEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class GetById : EndpointBaseAsync.WithRequest<GetPlayerByIdRequest>.WithActionResult<GetPlayerByIdResponse>
{
  private readonly IReadRepository<Player> _playerRepository;

  public GetById(IReadRepository<Player> playerRepository)
  {
    _playerRepository = playerRepository;
  }

  [HttpGet(GetPlayerByIdRequest.Route)]
  [SwaggerOperation(
    Summary = "Gets a single Mission",
    Description = "Gets a single Mission by Id",
    OperationId = "Missions.GetById",
    Tags = new[] { "MissionEndpoints" })]
  public override async Task<ActionResult<GetPlayerByIdResponse>> HandleAsync([FromRoute] GetPlayerByIdRequest request, CancellationToken cancellationToken = new())
  {
    var spec = new PlayerByPlayerIdSpec(request.PlayerId);
    var player = await _playerRepository.FirstOrDefaultAsync(spec);

    if (player == null)
    {
      return NotFound();
    }

    var response = new GetPlayerByIdResponse(new PlayerRecord(player.Id, player.DeviceId, player.GameId, player.Level,
      player.LastAdWatch, player.Rated, player.LastConnectedIP, player.LocaleCode));


    return Ok(response);
  }
}
