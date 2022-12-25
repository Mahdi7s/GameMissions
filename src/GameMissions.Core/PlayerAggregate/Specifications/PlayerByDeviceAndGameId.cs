using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using GameMissions.Core.GameAggregate;

namespace GameMissions.Core.PlayerAggregate.Specifications;
public class PlayerByDeviceAndGameId : Specification<Player>, ISingleResultSpecification<Player>
{
  public PlayerByDeviceAndGameId(string deviceId, int gameId)
  {
    Query.Where(x => x.DeviceId == deviceId && x.GameId == gameId);
  }
}
