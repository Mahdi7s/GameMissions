using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.Core.GameAggregate;
using GameMissions.SharedKernel;

namespace GameMissions.Core.PlayerAggregate;
public class Player : EntityBase
{
  public Device? Device { get; set; }
  public string? DeviceId { get; set; }
  public string? LastConnectedIP { get; set; }
  public string LocaleCode { get; set; } = "en";  
  public int GameId { get; set; }
  public Game Game { get; set; } = null!;
  public int Level { get; set; }
  public DateTime LastAdWatch { get; set; }
  public IList<Mission> ClaimedMissions { get; set; } = new List<Mission>();
}
