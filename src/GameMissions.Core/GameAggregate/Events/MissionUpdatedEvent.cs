using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.GameAggregate.Events;
public class MissionUpdatedEvent : DomainEventBase
{
  public Mission UpdatedMission { get; set; }
  public MissionUpdatedEvent(Mission updatedMission)
  {
    UpdatedMission = updatedMission;
  }
}
