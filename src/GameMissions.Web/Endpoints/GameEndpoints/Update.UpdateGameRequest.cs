using System.ComponentModel.DataAnnotations;

namespace GameMissions.Web.Endpoints.GameEndpoints;

public class UpdateGameRequest
{
  public const string Route = "/Games";

  [Required]
  public string Title { get; private set; } = string.Empty;
  [Required]
  public string PackageName { get; private set; } = string.Empty;
  public int NextRewardedVideoTimeout { get; private set; } = 90; // seconds
  public int RewardedVideoReward { get; private set; } = 50; // seconds
  public int IntrestitialPerLevel { get; private set; } = 2;
  public string Description { get; private set; } = string.Empty;
}
