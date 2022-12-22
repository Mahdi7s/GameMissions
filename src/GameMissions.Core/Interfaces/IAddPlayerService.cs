﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using GameMissions.Core.PlayerAggregate;

namespace GameMissions.Core.Interfaces;
public interface IAddPlayerService
{
  Task<Result<int>> AddPlayer(Player playerToAdd);
}
