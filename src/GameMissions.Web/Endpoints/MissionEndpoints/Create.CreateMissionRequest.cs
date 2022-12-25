using System.ComponentModel.DataAnnotations;
using GameMissions.Core.GameAggregate;

namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class CreateMissionRequest
{
  public const string Route = "/Missions";

  [Required]
  public int GameId { get; private set; }
  [Required]
  public int MissionType { get; private set; }
  [Required]
  public int CompletionLevel { get; private set; }
  public string? Title { get; private set; }
  public int Order { get; private set; }
  public int Reward { get; private set; }
  public string? Description { get; private set; }
}
