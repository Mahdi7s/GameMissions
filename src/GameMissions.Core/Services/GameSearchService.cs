using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using GameMissions.Core.GameAggregate;
using GameMissions.Core.GameAggregate.Specifications;
using GameMissions.Core.Interfaces;
using GameMissions.SharedKernel.Interfaces;

namespace GameMissions.Core.Services;
public class GameSearchService : IGameSearchService
{
  private readonly IReadRepository<Game> _repository;

  public GameSearchService(IReadRepository<Game> repository) {
    _repository = repository;
  }

  public async Task<Result<List<Game>>> GetAllGamesAsync()
  {
    var gameSpec = new AllGamesSpec();
    var games = await _repository.ListAsync(gameSpec);

    if(games == null || games.Count() == 0)
    {
      return Result<List<Game>>.NotFound();
    }

    return new Result<List<Game>>(games);
  }

  public async Task<Result<Game>> GetGameWithMissionsAsync(int gameId)
  {
    var gameSpec = new GameWithMissionsByGameIdSpec(gameId);
    var game = await _repository.FirstOrDefaultAsync(gameSpec);

    if(game == null)
    {
      return Result<Game>.NotFound();
    }

    return new Result<Game>(game);
  }
}
