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
  public MissionClaimedEvent(Mission claimedMission) 
  {
    ClaimedMission = claimedMission;
  }

  public Mission ClaimedMission { get; }
}
