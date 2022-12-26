using Ardalis.ApiEndpoints;
using GameMissions.Core.PlayerAggregate;
using GameMissions.Core.PlayerAggregate.Specifications;
using GameMissions.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class Delete : EndpointBaseAsync.WithRequest<DeletePlayerRequest>.WithoutResult
{
  private readonly IRepository<Player> _playerRepository;

  public Delete(IRepository<Player> playerRepository)
  {
    _playerRepository = playerRepository;
  }
  public override async Task<ActionResult> HandleAsync(DeletePlayerRequest request, CancellationToken cancellationToken = new())
  {
    var spec = new PlayerByPlayerIdSpec(request.PlayerId);
    var playerToDelete = await _playerRepository.GetBySpecAsync(spec);
    
    if (playerToDelete == null)
    {
      return NotFound();
    }

    await _playerRepository.DeleteAsync(playerToDelete);

    return NoContent();
  }
}
