using GameMissions.Core.GameAggregate;

namespace GameMissions.Web.Endpoints.GameEndpoints;

public class CreateGameResponse 
{
  public CreateGameResponse(int id, string title, string packageName, int nextRewardedVideoTimeout, int rewardedVideoReward, int intrestitialPerLevel, string description)
  {
    Id = id;
    Title = title;
    PackageName = packageName;
    NextRewardedVideoTimeout = nextRewardedVideoTimeout;
    RewardedVideoReward = rewardedVideoReward;
    IntrestitialPerLevel = intrestitialPerLevel;
    Description = description;
  }
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string PackageName { get; set; } = string.Empty;
  public int NextRewardedVideoTimeout { get; set; } = 90; // seconds
  public int RewardedVideoReward { get; set; } = 50; // seconds
  public int IntrestitialPerLevel { get; set; } = 2;
  public string Description { get; set; } = string.Empty;
}
