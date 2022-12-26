using Ardalis.ApiEndpoints;
using GameMissions.Core.GameAggregate;
using GameMissions.SharedKernel.Interfaces;
using GameMissions.Web.Endpoints.GameEndpoints;
using GameMissions.Web.Endpoints.PlayerEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class Update : EndpointBaseAsync.WithRequest<UpdateMissionRequest>.WithActionResult<UpdateMissionResponse>
{
  private readonly IRepository<Mission> _missionRepository;

  public Update(IRepository<Mission> missionRepository)
  {
    _missionRepository = missionRepository;
  }

  [HttpPut(UpdateMissionRequest.Route)]
  [SwaggerOperation(
  Summary = "Updates a Mission",
  Description = "Updates a Mission",
  OperationId = "Mission.Update",
  Tags = new[] { "MissionEndpoints" })]
  public override async Task<ActionResult<UpdateMissionResponse>> HandleAsync(UpdateMissionRequest request, CancellationToken cancellationToken = new())
  {
    var mission = await _missionRepository.GetByIdAsync(request.Id);
    
    if (mission == null)
    {
      return NotFound();
    }

    mission.UpdateTitle(request.Title);
    mission.UpdateGameId(request.GameId);
    mission.UpdateMissionType(request.MissionType);
    mission.UpdateCompletionLevel(mission.CompletionLevel);
    mission.UpdateDescription(request.Description);
    mission.UpdateOrder(request.Order);
    mission.UpdateReward(request.Reward);

    var response = new UpdateMissionResponse(new MissionRecord(mission.Id, mission.GameId, (int)mission.MissionType, 
      mission.Order, mission.Title,  mission.CompletionLevel, mission.Reward, mission.Description));

    return Ok(mission);
  }
}
