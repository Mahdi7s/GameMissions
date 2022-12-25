using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace GameMissions.Core.PlayerAggregate.Specifications;
public class PlayerByPlayerIdSpec : Specification<Player>, ISingleResultSpecification<Player>
{
  public PlayerByPlayerIdSpec(int playerId)
  {
    Query.Where(x => x.Id == playerId);
  }
}
