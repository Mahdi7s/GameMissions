using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace GameMissions.Core.GameAggregate.Specifications;
public class MissionWithGameByMissionIdSpec : Specification<Mission>, ISingleResultSpecification<Mission>
{
  public MissionWithGameByMissionIdSpec(int missionId)
  {
    Query.Where(x => x.Id == missionId).Include(x => x.Game);
  }
}
