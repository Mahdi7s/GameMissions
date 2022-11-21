using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;
using GameMissions.SharedKernel.Interfaces;

namespace GameMissions.Core.GameAggregate;
public class Mission : EntityBase, IAggregateRoot
{
  public int GameId { get; set; }
  public Game Game { get; set; } = null!;
  public MissionType MissionType { get; set; }
  public int CompletionLevel { get; set; }
  public string? Title { get; set; }
  public int Order { get; set; }
  public int Reward { get; set; }
  public string? Description { get; set; }
}
