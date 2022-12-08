using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using GameMissions.Core.GameAggregate.Events;
using GameMissions.SharedKernel;
using GameMissions.SharedKernel.Interfaces;

namespace GameMissions.Core.GameAggregate;
public class Game : EntityBase, IAggregateRoot
{
  public Game(string title, string packageName, int nextRewardedVideoTimeout = 90, int rewardedVideoReward = 50, int intrestitialPerLevel = 2, string description = null)
  {
    UpdateTitle(title);
    UpdatePackageName(packageName);
    UpdateNextRewardedVideoTimeout(nextRewardedVideoTimeout);
    UpdateRewardedVideoReward(rewardedVideoReward);
    UpdateIntrestitialPerLevel(intrestitialPerLevel);
    UpdateDescription(description);
  }
  public string Title { get; private set; } = string.Empty;
  public string PackageName { get; private set; } = string.Empty;
  public int NextRewardedVideoTimeout { get; private set; } = 90; // seconds
  public int RewardedVideoReward { get; private set; } = 50; // seconds
  public int IntrestitialPerLevel { get; private set; } = 2;
  public string Description { get; private set; } = string.Empty;

  private IList<Mission> _missions = new List<Mission>();
  public IList<Mission> Missions => _missions.AsReadOnly();
  public void AddMission(Mission mission)
  {
    Guard.Against.Null(mission, nameof(mission));
    _missions.Add(mission);

    var missionAddedEvent = new MissionAddedEvent(mission);
    base.RegisterDomainEvent(missionAddedEvent);
  }

  public void UpdateTitle(string title)
  {
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
  }
  public void UpdatePackageName(string packageName)
  {
    PackageName = Guard.Against.NullOrEmpty(packageName, nameof(packageName));
  }
  public void UpdateNextRewardedVideoTimeout(int nextRewardedVideoTimeout)
  {
    NextRewardedVideoTimeout = Guard.Against.NegativeOrZero(nextRewardedVideoTimeout, nameof(nextRewardedVideoTimeout));
  }
  public void UpdateRewardedVideoReward(int rewardedVideoReward)
  {
    RewardedVideoReward = Guard.Against.NegativeOrZero(rewardedVideoReward, nameof(rewardedVideoReward));
  }
  public void UpdateIntrestitialPerLevel(int intrestitialPerLevel)
  {
    IntrestitialPerLevel = Guard.Against.NegativeOrZero(intrestitialPerLevel, nameof(intrestitialPerLevel));
  }
  public void UpdateDescription(string description)
  {
    Description = description;
  }
}
