using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.PlayerAggregate.Events;
public class PlayerUpdatedEvent : DomainEventBase
{
  public PlayerUpdatedEvent(Player updatedPlayer)
  {
    UpdatedPlayer = updatedPlayer;
  }

  public Player UpdatedPlayer { get; }
}
