using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.GameAggregate.Events;
public class MissionAddedEvent : DomainEventBase
{
  public Mission NewMission { get; set; }

  public MissionAddedEvent(Mission newMission)
  {
    NewMission = newMission;
  }
}
