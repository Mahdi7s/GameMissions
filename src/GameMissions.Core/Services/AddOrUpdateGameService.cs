using System;
using System.Collections.Generic;
using System.ComponentModel;
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

  public async Task<Result<Game>> AddOrUpdate(Game game)
  {
    var gameInDb = _repository.GetByIdAsync(game.Id);
    if(gameInDb == null) // add
    {
      try
      {
        game = await _repository.AddAsync(game);

        await _mediator.Publish(new GameAddedEvent(game));
      }
      catch(Exception ex)
      {
        return Result<Game>.Error("Game Insert Error", ex.Message);
      }
    }
    else // update
    {
      try
      {
        await _repository.UpdateAsync(game);

        await _mediator.Publish(new GameUpdatedEvent(game));
      }
      catch(Exception ex)
      {
        return Result<Game>.Error("Game Update Error", ex.Message);
      }
    }

    return new Result<Game>(game);
  }
}
