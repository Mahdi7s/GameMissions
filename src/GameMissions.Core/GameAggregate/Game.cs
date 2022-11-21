using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;
using GameMissions.SharedKernel.Interfaces;

namespace GameMissions.Core.GameAggregate;
public class Game : EntityBase, IAggregateRoot
{
  public string Title { get; set; } = string.Empty;
  public string PackageName { get; set; } = string.Empty;
  public int NextRewardedVideoTimeout { get; set; } = 90; // seconds
  public int RewardedVideoReward { get; set; } = 50; // seconds
  public int IntrestitialPerLevel { get; set; } = 2;
  public string Description { get; set; } = string.Empty;

  public IList<Mission> Missions { get; set; } = new List<Mission>();
}
