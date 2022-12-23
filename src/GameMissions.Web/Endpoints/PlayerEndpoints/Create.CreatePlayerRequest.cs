using System.ComponentModel.DataAnnotations;

namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class CreatePlayerRequest
{
  public const string Route = "/Players";

  [Required]
  public string DeviceId { get; set; }
  [Required]
  public string GamePackageName { get; set; }
}
