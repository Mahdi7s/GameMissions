using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using GameMissions.SharedKernel;
using GameMissions.SharedKernel.Interfaces;

namespace GameMissions.Core.GameAggregate;
public class Mission : EntityBase, IAggregateRoot
{
  public Mission(int gameId, int missionType, int order, string? title, int completionLevel, int reward, string? description)
  {
    UpdateGameId(gameId);
    UpdateMissionType(missionType);
    UpdateCompletionLevel(completionLevel);
    UpdateTitle(title);
    UpdateOrder(order);
    UpdateReward(reward);
    UpdateDescription(description);
  }
  public int GameId { get; private set; }
  public Game Game { get; private set; } = null!;
  public MissionType MissionType { get; private set; }
  public int CompletionLevel { get; private set; }
  public string? Title { get; private set; }
  public int Order { get; private set; }
  public int Reward { get; private set; }
  public string? Description { get; private set; }

  public void UpdateGameId(int gameId)
  {
    GameId = gameId;
  }
  public void UpdateGame(Game game)
  {
    Game = Guard.Against.Null(game);
  }
  public void UpdateMissionType(int missionType)
  {
    MissionType = (MissionType)Guard.Against.EnumOutOfRange<MissionType>(missionType, nameof(missionType));
  }
  public void UpdateCompletionLevel(int completionLevel)
  {
    CompletionLevel = Guard.Against.NegativeOrZero(completionLevel, nameof(completionLevel));
  }
  public void UpdateTitle(string title)
  {
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
  }
  public void UpdateOrder(int order)
  {
    Order = Guard.Against.NegativeOrZero(order, nameof(order));
  }
  public void UpdateReward(int reward)
  {
    Reward = Guard.Against.NegativeOrZero(reward, nameof(reward));
  }
  public void UpdateDescription(string description)
  {
    Description = description;
  }
}
