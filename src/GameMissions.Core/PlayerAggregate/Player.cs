using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using GameMissions.Core.GameAggregate;
using GameMissions.Core.PlayerAggregate.Events;
using GameMissions.SharedKernel;
using GameMissions.SharedKernel.Interfaces;

namespace GameMissions.Core.PlayerAggregate;
public class Player : EntityBase, IAggregateRoot
{
  public Player(string? deviceId, int gameId, int level, DateTime lastAdWatch, bool rated = false, string? lastConnectedIP = null, string localeCode = "en")
  {
    UpdateDeviceId(deviceId);
    UpdateLastConnectedIP(lastConnectedIP);
    UpdateLocaleCode(localeCode);
    UpdateRated(rated);
    UpdateGameId(gameId);
    UpdateLevel(level);
    UpdateLastAdWatch(lastAdWatch);
  }

  public Device? Device { get; private set; }
  public string? DeviceId { get; private set; }

  public string? LastConnectedIP { get; private set; }
  public string LocaleCode { get; private set; } = "en";
  public int GameId { get; private set; }
  public Game Game { get; private set; } = null!;
  public bool Rated { get; private set; }
  public int Level { get; private set; }
  public DateTime LastAdWatch { get; private set; }
  private IList<Mission> _claimedMissions = new List<Mission>();
  public IList<Mission> ClaimedMissions => _claimedMissions.AsReadOnly();
  public void ClaimMission(Mission mission)
  {
    _claimedMissions.Add(mission);
    base.RegisterDomainEvent(new MissionClaimedEvent(this, mission));
  }
  public void UpdateDeviceId(string deviceId)
  {
    DeviceId = Guard.Against.NullOrEmpty(deviceId, nameof(deviceId));
  }
  public void UpdateDevice(Device device)
  { 
    Device = Guard.Against.Null(device, nameof(device));
  }
  public void UpdateRated(bool rated)
  {
    Rated = rated;
  }
  public void UpdateGame(Game game)
  {
    Game = Guard.Against.Null(game, nameof(game));
  }
  public void UpdateGameId(int gameId)
  {
    GameId = gameId;
  }
  public void UpdateLastConnectedIP(string lastConnectedIP)
  {
    LastConnectedIP = Guard.Against.NullOrEmpty(lastConnectedIP, nameof(lastConnectedIP));
  }
  public void UpdateLocaleCode(string localeCode)
  {
    LocaleCode = Guard.Against.NullOrEmpty(localeCode, nameof(localeCode));
  }
  public void UpdateLevel(int level)
  {
    Level = Guard.Against.NegativeOrZero(level, nameof(level));
  }
  public void UpdateLastAdWatch(DateTime lastAdWatch)
  {
    LastAdWatch = lastAdWatch;
  }
}
