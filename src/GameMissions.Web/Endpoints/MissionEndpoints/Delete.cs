using Ardalis.ApiEndpoints;
using GameMissions.Core.GameAggregate;
using GameMissions.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class Delete : EndpointBaseAsync.WithRequest<DeleteMissionRequest>.WithoutResult
{
  private readonly IRepository<Mission> _missionRepository;

  public Delete(IRepository<Mission> missionRepository)
  {
    _missionRepository = missionRepository;
  }

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
