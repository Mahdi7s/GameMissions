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
public class UpdateGameService : IUpdateGameService
{
  private readonly IRepository<Game> _repository;
  private readonly IMediator _mediator;

  public UpdateGameService(IRepository<Game> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public async Task<Result> UpdateGame(Game gameToUpdate)
  {
    try
    {
      await _repository.UpdateAsync(gameToUpdate);

      await _mediator.Publish(new GameUpdatedEvent(gameToUpdate));
    }
    catch (Exception ex)
    {
      return Result.Error("Game Update Error", ex.Message);
    }

    return Result.Success();
  }
}
