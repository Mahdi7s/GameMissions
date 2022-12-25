using Ardalis.ApiEndpoints;
using GameMissions.Core.GameAggregate;
using GameMissions.Core.GameAggregate.Specifications;
using GameMissions.SharedKernel.Interfaces;
using GameMissions.Web.Endpoints.ProjectEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class GetById : EndpointBaseAsync.WithRequest<GetMissionByIdRequest>.WithActionResult<GetMissionByIdResponse>
{
  private readonly IReadRepository<Mission> _missionRepository;

  public GetById(IReadRepository<Mission> missionRepository)
  {
    _missionRepository = missionRepository;
  }

  [HttpGet(GetProjectByIdRequest.Route)]
  [SwaggerOperation(
  Summary = "Gets a single Mission",
  Description = "Gets a single Mission by Id",
  OperationId = "Missions.GetById",
  Tags = new[] { "MissionEndpoints" })]
  public async override Task<ActionResult<GetMissionByIdResponse>> HandleAsync([FromRoute]GetMissionByIdRequest request, CancellationToken cancellationToken = new())
  {
    var spec = new MissionWithGameByMissionIdSpec(request.MissionId);
    var mission = await _missionRepository.FirstOrDefaultAsync(spec, cancellationToken);

    if(mission == null)
    {
      return NotFound();
    }

    var response = new GetMissionByIdResponse(new MissionRecord(mission.Id, mission.GameId, (int)mission.MissionType,
      mission.Order, mission.Title, mission.CompletionLevel, mission.Reward, mission.Description));

    return Ok(response);
  }
}
