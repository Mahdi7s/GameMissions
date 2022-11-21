using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.Core.GameAggregate.Events;
using GameMissions.Core.ProjectAggregate;
using GameMissions.SharedKernel.Interfaces;
using MediatR;

namespace GameMissions.Core.GameAggregate.Handlers;
public class GameAddedHandler : INotificationHandler<GameAddedEvent>
{
  private readonly IRepository<Game> _repository;

  public GameAddedHandler(IRepository<Game> repository)
  {
    _repository = repository;
  }
  public async Task Handle(GameAddedEvent notification, CancellationToken cancellationToken)
  {
    await _repository.AddAsync(notification.NewGame, cancellationToken);
  }
}
