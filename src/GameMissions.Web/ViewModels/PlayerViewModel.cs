using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.Core.GameAggregate;
using GameMissions.Core.PlayerAggregate;

namespace GameMissions.Web.ViewModels;
public class PlayerViewModel
{
  private readonly IEnumerable<Mission> _allMissions;

  public PlayerViewModel(IEnumerable<Mission> allMissions)
  {
    _allMissions = allMissions;
  }

  public bool CanRate => !Player.Rated;
  public bool CanWatchAd => Player.LastAdWatch.AddSeconds(Player.Game.NextRewardedVideoTimeout) <= DateTime.Now;
  public IList<Mission> RefferalMissions { get; set; }
  /// <summary>
  /// Current player with his/her device, playing game and claimed missions
  /// </summary>
  public Player Player { get; set; }
  /// <summary>
  /// Install MissionType : Other games except this one
  /// GotoLevel MissionType : This game missions
  /// Games except the player's game, with their missions, ordered by the game order
  /// Each game has one Install Mission followed by a Completion Level that installer player need to finish to get the reward
  /// </summary>
  public IList<Mission> InstallMissions => _allMissions.Where(m => m.GameId != Player.GameId &&
    m.MissionType == MissionType.Install && !Player.ClaimedMissions.Any(c => c.Id == m.Id))
    .OrderBy(m => m.Order).ToList();
  /// <summary>
  /// Current game's missions with MissionType of GotoLevel, orderd by Order
  /// </summary>
  public IList<Mission> AllGotoLevelMissions => _allMissions.Where(m => m.MissionType == MissionType.GotoLevel
    && m.GameId == Player.GameId).OrderBy(m => m.Order).ToList();

  public IList<Mission> ClaimedGotoLevelMissions => Player.ClaimedMissions.Where(m => m.MissionType == MissionType.GotoLevel)
    .OrderBy(m => m.Order).ToList();

  public Mission CurrentGotoLevelMission => AllGotoLevelMissions.Skip(ClaimedGotoLevelMissions.Count()).FirstOrDefault();
}


