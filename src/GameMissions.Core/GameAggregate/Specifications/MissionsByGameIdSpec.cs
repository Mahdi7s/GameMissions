using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace GameMissions.Core.GameAggregate.Specifications;
public class MissionsByGameIdSpec : Specification<Mission>, ISingleResultSpecification
{
  public MissionsByGameIdSpec(int gameId)
  {
    Query.Where(x => x.GameId == gameId).Include(x => x.Game);
  }
}
