using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.PlayerAggregate.Events;
public class PlayerAddedEvent : DomainEventBase
{
  public PlayerAddedEvent(Player newPlayer)
  {
    NewPlayer = newPlayer;
  }

  public Player NewPlayer { get; }
}
