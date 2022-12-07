using GameMissions.Core.GameAggregate;

namespace GameMissions.Web.Endpoints.GameEndpoints;

public record GameRecord(int Id, string Title, string PackageName, int NextRewardedVideoTimeout, int RewardedVideoReward, int IntrestitialPerLevel, string Description);

