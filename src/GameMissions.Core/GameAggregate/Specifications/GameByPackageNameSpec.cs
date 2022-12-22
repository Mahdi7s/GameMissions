using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace GameMissions.Core.GameAggregate.Specifications;
public class GameByPackageNameSpec : Specification<Game>, ISingleResultSpecification<Game>
{
  public GameByPackageNameSpec(string packageName)
  {
    Query.Where(g => g.PackageName == packageName);
  }
}
