using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.GameAggregate.Events;
public class GameAddedEvent : DomainEventBase
{
  public Game NewGame { get; set; }

  public GameAddedEvent(Game newGame)
  {
    NewGame = newGame;
  }
}
