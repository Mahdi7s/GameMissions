using Ardalis.ApiEndpoints;
using GameMissions.Core.GameAggregate;
using GameMissions.Core.GameAggregate.Specifications;
using GameMissions.Core.Interfaces;
using GameMissions.Core.PlayerAggregate;
using GameMissions.SharedKernel.Interfaces;
using GameMissions.Web.Endpoints.GameEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class Create : EndpointBaseAsync.WithRequest<CreatePlayerRequest>.WithActionResult<CreatePlayerResponse>
{
  private readonly IAddPlayerService _addPlayerService;
  private readonly IRepository<Game> _gameRepository;

  public Create(IAddPlayerService addPlayerService, IRepository<Game> gameRepository)
  {
    _addPlayerService = addPlayerService;
    _gameRepository = gameRepository;
  }

  [HttpPost(CreatePlayerRequest.Route)]
  [SwaggerOperation(
  Summary = "Creates a new Player and Device (if not exists)",
  Description = "Creates a new Player",
  OperationId = "Player.Create",
  Tags = new[] { "PlayerEndpoints" })]
  public override async Task<ActionResult<CreatePlayerResponse>> HandleAsync(CreatePlayerRequest request, CancellationToken cancellationToken = default)
  {
    if(string.IsNullOrEmpty(request.GamePackageName) || string.IsNullOrEmpty(request.DeviceId))
    {
      return BadRequest();
    }

    var game = await _gameRepository.GetBySpecAsync(new GameByPackageNameSpec(request.GamePackageName));
    
    var result = await _addPlayerService.AddPlayer(new Player(request.DeviceId, game.Id, 1, DateTime.Now));

    var response = new CreatePlayerResponse(result.Value);

    return Ok(response);
  }
}
