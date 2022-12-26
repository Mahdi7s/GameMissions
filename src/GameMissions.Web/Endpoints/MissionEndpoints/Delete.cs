using Ardalis.ApiEndpoints;
using GameMissions.Core.GameAggregate;
using GameMissions.SharedKernel.Interfaces;
using GameMissions.Web.Endpoints.GameEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class Delete : EndpointBaseAsync.WithRequest<DeleteMissionRequest>.WithoutResult
{
  private readonly IRepository<Mission> _missionRepository;

  public Delete(IRepository<Mission> missionRepository)
  {
    _missionRepository = missionRepository;
  }

  [HttpDelete(DeleteMissionRequest.Route)]
  [SwaggerOperation(
    Summary = "Deletes a Mission",
    Description = "Deletes a Mission",
    OperationId = "Mission.Delete",
    Tags = new[] { "MissionEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(DeleteMissionRequest request, CancellationToken cancellationToken = new())
  {
    var missionToDelete = await _missionRepository.GetByIdAsync(request.MissionId);
    
    if (missionToDelete == null) 
    {
      return NotFound();
    }

    await _missionRepository.DeleteAsync(missionToDelete, cancellationToken);

    return NoContent();
  }
}
