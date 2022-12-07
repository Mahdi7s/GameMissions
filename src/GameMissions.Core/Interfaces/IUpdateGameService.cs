using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using GameMissions.Core.GameAggregate;

namespace GameMissions.Core.Interfaces;
public interface IUpdateGameService
{
  Task<Result> UpdateGame(Game gameToUpdate);
}
