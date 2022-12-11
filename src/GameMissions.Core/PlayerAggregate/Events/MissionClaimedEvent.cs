using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.Core.GameAggregate;
using GameMissions.SharedKernel;

namespace GameMissions.Core.PlayerAggregate.Events;
public class MissionClaimedEvent : DomainEventBase
{
  public MissionClaimedEvent(Player player, Mission claimedMission) 
  {
    Player = player;
    ClaimedMission = claimedMission;
  }

  public Player Player { get; }
  public Mission ClaimedMission { get; }
}
