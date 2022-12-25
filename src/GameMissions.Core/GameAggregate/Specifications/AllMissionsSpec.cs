using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace GameMissions.Core.GameAggregate.Specifications;
public class AllMissionsSpec : Specification<Mission>
{
  public AllMissionsSpec() 
  {
    Query.Include(x => x.Game);
  }
}
