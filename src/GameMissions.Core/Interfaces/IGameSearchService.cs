using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using GameMissions.Core.GameAggregate;

namespace GameMissions.Core.Interfaces;
public interface IGameSearchService
{
  Task<Result<List<Game>>> GetAllGamesAsync();
  Task<Result<Game>> GetGameWithMissionsAsync(int gameId);
}
