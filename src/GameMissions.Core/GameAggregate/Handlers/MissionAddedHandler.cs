using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.Core.GameAggregate.Events;
using GameMissions.SharedKernel.Interfaces;
using MediatR;

namespace GameMissions.Core.GameAggregate.Handlers;
public class MissionAddedHandler : INotificationHandler<MissionAddedEvent>
{
  private readonly IRepository<Mission> _repository;

  public MissionAddedHandler(IRepository<Mission> repository)
  {
    _repository = repository;
  }
  public async Task Handle(MissionAddedEvent notification, CancellationToken cancellationToken)
  {
    //await _repository.AddAsync(notification.)
  }
}
