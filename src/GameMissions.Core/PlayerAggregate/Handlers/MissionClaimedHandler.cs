using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.Core.PlayerAggregate.Events;
using MediatR;

namespace GameMissions.Core.PlayerAggregate.Handlers;
public class MissionClaimedHandler : INotificationHandler<MissionClaimedEvent>
{
  public Task Handle(MissionClaimedEvent claimedMissionEvent, CancellationToken cancellationToken)
  {
    if (claimedMissionEvent.ClaimedMission.MissionType == MissionType.Install)
    {
      //claimedMissionEvent.Player.Device.
    }

    return Task.CompletedTask;
  }
}
