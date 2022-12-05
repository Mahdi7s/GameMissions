using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;

namespace GameMissions.Core.Interfaces;
public interface IDeleteGameService
{
  public Task<Result> DeleteGame(int gameId);
}
