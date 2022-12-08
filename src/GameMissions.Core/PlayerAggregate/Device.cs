using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using GameMissions.Core.PlayerAggregate.Events;
using GameMissions.SharedKernel;
using GameMissions.SharedKernel.Interfaces;

namespace GameMissions.Core.PlayerAggregate;
public class Device : EntityBase, IAggregateRoot
{
  private IList<Player> _players = new List<Player>();

  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public new string Id { get; private set; }

  public Device(string id)
  {
    UpdateId(id);
  }

  public IList<Player> Players => _players.AsReadOnly();
  public void AddPlayer(Player player)
  {
    _players.Add(player);

    base.RegisterDomainEvent(new PlayerAddedEvent(player));
  }

  public void UpdateId(string id)
  {
    Id = Guard.Against.NullOrEmpty(id, nameof(id));
  }
}
