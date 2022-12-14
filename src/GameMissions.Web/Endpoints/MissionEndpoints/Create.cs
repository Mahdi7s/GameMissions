using Ardalis.ApiEndpoints;
using GameMissions.Core.GameAggregate;
using GameMissions.SharedKernel.Interfaces;
using GameMissions.Web.Endpoints.PlayerEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class Create : EndpointBaseAsync.WithRequest<CreateMissionRequest>.WithActionResult<CreateMissionResponse>
{
  private readonly IRepository<Mission> _missionRepository;

  public Create(IRepository<Mission> missionRepository)
  {
    _missionRepository = missionRepository;
  }

  [HttpPost(CreatePlayerRequest.Route)]
  [SwaggerOperation(
    Summary = "Creates a new Mission",
    Description = "Creates a new Mission",
    OperationId = "Mission.Create",
    Tags = new[] { "MissionEndpoints" })]
  public override async Task<ActionResult<CreateMissionResponse>> HandleAsync(CreateMissionRequest request, CancellationToken cancellationToken = new())
  {
    if (string.IsNullOrEmpty(request.Title))
    {
      return BadRequest();
    }

    var addedMission = await _missionRepository.AddAsync(new Mission(request.GameId, request.MissionType, request.Order, request.Title, request.CompletionLevel, request.Reward, request.Description), cancellationToken);

    var response = new CreatePlayerResponse(addedMission.Id);

    return Ok(response);
  }
}
