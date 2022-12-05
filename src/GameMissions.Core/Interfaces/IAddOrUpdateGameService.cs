using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using GameMissions.Core.GameAggregate;

namespace GameMissions.Core.Interfaces;
public interface IAddOrUpdateGameService
{
  Task<Result> AddOrUpdate(Game game);
}
