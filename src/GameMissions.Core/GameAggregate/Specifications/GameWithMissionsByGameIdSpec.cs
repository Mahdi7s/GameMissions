using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace GameMissions.Core.GameAggregate.Specifications;
public class GameWithMissionsByGameIdSpec : Specification<Game>
{
  public GameWithMissionsByGameIdSpec(int gameId)
  {
    Query.Where(g => g.Id == gameId).Include(g => g.Missions);
  }
}
