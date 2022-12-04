using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using GameMissions.Core.GameAggregate;
using GameMissions.Core.GameAggregate.Events;
using GameMissions.Core.Interfaces;
using GameMissions.SharedKernel.Interfaces;
using MediatR;

namespace GameMissions.Core.Services;
public class AddOrUpdateGameService : IAddOrUpdateGameService
{
  private readonly IRepository<Game> _repository;
  private readonly IMediator _mediator;

  public AddOrUpdateGameService(IRepository<Game> repository, IMediator mediator) {
    _repository = repository;
    _mediator = mediator;
  }

  public Task<Result> AddOrUpdate(Game game)
  {
    var gameInDb = _repository.GetByIdAsync(game.Id);
    if(gameInDb == null) // add
    {

      _mediator.Send(new GameAddedEvent(game));
    }
    else // update
    {
      _mediator.Send(new GameUpdatedEvent(game));
    }
  }
}
