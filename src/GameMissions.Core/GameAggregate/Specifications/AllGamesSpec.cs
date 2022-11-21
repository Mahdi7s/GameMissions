using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace GameMissions.Core.GameAggregate.Specifications;
public class AllGamesSpec : Specification<Game>
{
  public AllGamesSpec() 
  {
    Query.Include(x => x.Missions);
  }
}
