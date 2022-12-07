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
public class AddGameService : IAddGameService
{
  private readonly IRepository<Game> _repository;
  private readonly IMediator _mediator;

  public AddGameService(IRepository<Game> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public async Task<Result<int>> AddGame(Game gameToAdd)
  {
    try
    {
      gameToAdd = await _repository.AddAsync(gameToAdd);

      await _mediator.Publish(new GameAddedEvent(gameToAdd));
    }
    catch (Exception ex)
    {
      return Result<int>.Error("Game Insert Error", ex.Message);
    }

    return Result.Success(gameToAdd.Id);
  }
}
