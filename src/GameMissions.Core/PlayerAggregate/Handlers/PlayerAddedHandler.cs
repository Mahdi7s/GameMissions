using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.Core.GameAggregate;
using GameMissions.Core.GameAggregate.Specifications;
using GameMissions.Core.PlayerAggregate.Events;
using GameMissions.SharedKernel.Interfaces;
using MediatR;

namespace GameMissions.Core.PlayerAggregate.Handlers;
public class PlayerAddedHandler : INotificationHandler<PlayerAddedEvent>
{
  private readonly IRepository<Mission> _missionRepository;

  public PlayerAddedHandler(IRepository<Mission> missionRepository)
  {
    _missionRepository = missionRepository;
  }

  public async Task Handle(PlayerAddedEvent playerAddedNotif, CancellationToken cancellationToken)
  {
    var player = playerAddedNotif.NewPlayer;
    var otherDevicePlayers = player.Device!.Players.Where(p => p.Id != player.Id).ToList();
    
    foreach (var otherDevicePlayer in otherDevicePlayers)
    {
      var gameInstallMission = await _missionRepository.FirstOrDefaultAsync(new MissionsByGameIdAndTypeSpec(otherDevicePlayer.GameId, MissionType.Install));
      if (gameInstallMission != null)
      {
        otherDevicePlayer.ClaimMission(gameInstallMission);
      }
    }

    await _missionRepository.SaveChangesAsync();
  }
}
