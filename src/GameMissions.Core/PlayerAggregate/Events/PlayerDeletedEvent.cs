using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.PlayerAggregate.Events;
public class PlayerDeletedEvent : DomainEventBase
{
  public PlayerDeletedEvent(Player player)
  {
    Player = player;
  }

  public Player Player { get; }
}
