using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.GameAggregate.Events;
public class MissionDeletedEvent : DomainEventBase
{
  public int MissionId { get; set; }
  public MissionDeletedEvent(int missionId)
  {
    MissionId = missionId;
  }
}
