using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace GameMissions.Core.GameAggregate.Specifications;
public class MissionsByGameIdAndTypeSpec : Specification<Mission>
{
  public MissionsByGameIdAndTypeSpec(int gameId, MissionType missionType)
  {
    Query.Where(m => m.GameId == gameId && m.MissionType == missionType);
  }
}
