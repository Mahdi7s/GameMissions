using System.ComponentModel.DataAnnotations;

namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class UpdateMissionRequest
{
  public const string Route = "/Missions";

  [Required]
  public int Id { get; set; }
  [Required]
  public int GameId { get; set; }
  [Required]
  public int MissionType { get; set; }
  [Required]
  public int CompletionLevel { get; set; }
  public string? Title { get; set; }
  public int Order { get; set; }
  public int Reward { get; set; }
  public string? Description { get; set; }
}
