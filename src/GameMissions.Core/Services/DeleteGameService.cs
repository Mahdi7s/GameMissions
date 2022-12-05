using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using GameMissions.Core.ContributorAggregate;
using GameMissions.Core.GameAggregate.Events;
using GameMissions.Core.Interfaces;
using GameMissions.SharedKernel.Interfaces;
using MediatR;

namespace GameMissions.Core.Services;
public class DeleteGameService : IDeleteGameService
{
  private readonly IRepository<Contributor> _repository;
  private readonly IMediator _mediator;

  public DeleteGameService(IRepository<Contributor> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public async Task<Result> DeleteGame(int gameId)
  {
    var gameToDelete = await _repository.GetByIdAsync(gameId);
    if (gameToDelete == null)
    {
      return Result.NotFound();
    }

    await _repository.DeleteAsync(gameToDelete);

    var domainEvent = new GameDeletedEvent(gameId);
    await _mediator.Send(domainEvent);

    return Result.Success();
  }
}
