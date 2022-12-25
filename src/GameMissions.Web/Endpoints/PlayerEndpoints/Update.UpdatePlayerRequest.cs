using System.ComponentModel.DataAnnotations;
using GameMissions.Core.GameAggregate;

namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class UpdatePlayerRequest
{
  public const string Route = "/Players";
  [Required]
  public int Id { get; set; }
  [Required]
  public string? DeviceId { get; set; }

  public string? LastConnectedIP { get; set; }
  public string LocaleCode { get; set; }
  public int GameId { get; set; }
  public bool Rated { get; set; }
  public int Level { get; set; }
  public DateTime LastAdWatch { get; set; }
}
