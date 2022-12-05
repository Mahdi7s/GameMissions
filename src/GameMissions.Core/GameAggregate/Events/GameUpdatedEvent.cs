using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.GameAggregate.Events;
public class GameUpdatedEvent : DomainEventBase
{
  public Game UpdatedGame { get; }

  public GameUpdatedEvent(Game updatedGame)
  {
    UpdatedGame = updatedGame;
  }
}
