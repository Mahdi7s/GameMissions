using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;
using GameMissions.SharedKernel.Interfaces;

namespace GameMissions.Core.PlayerAggregate;
public class Device : EntityBase, IAggregateRoot
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public new string Id { get; set; }
  public IList<Player> Players { get; set; } = new List<Player>();
}
