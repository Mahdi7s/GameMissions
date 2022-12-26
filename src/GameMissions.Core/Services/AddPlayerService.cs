using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using GameMissions.Core.Interfaces;
using GameMissions.Core.PlayerAggregate;
using GameMissions.SharedKernel.Interfaces;

namespace GameMissions.Core.Services;
public class AddPlayerService : IAddPlayerService
{
  private readonly IRepository<Player> _playerRepository;
  private readonly IRepository<Device> _deviceRepository;

  public AddPlayerService(IRepository<Player> playerRepository, IRepository<Device> deviceRepository)
  {
    _playerRepository = playerRepository;
    _deviceRepository = deviceRepository;
  }

  public async Task<Result<int>> AddPlayer(Player playerToAdd)
  {
    if(string.IsNullOrEmpty(playerToAdd.DeviceId))
    {
      return Result<int>.Error($"{nameof(playerToAdd.DeviceId)} is needed to add new player");
    }

    var device = await _deviceRepository.GetByIdAsync(playerToAdd.DeviceId);
    if (device == null)
    {
      device = await _deviceRepository.AddAsync(new Device(playerToAdd.DeviceId));
      playerToAdd.UpdateDevice(device);
    }

    playerToAdd = await _playerRepository.AddAsync(playerToAdd);

    return new Result<int>(playerToAdd.Id);
  }
}
