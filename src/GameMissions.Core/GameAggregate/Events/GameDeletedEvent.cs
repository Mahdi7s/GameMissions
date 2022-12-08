using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.GameAggregate.Events;
public class GameDeletedEvent : DomainEventBase
{
  public Game Game { get; set; }

  public GameDeletedEvent(Game game)
  {
    Game = game;
  }
}
