using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.PlayerAggregate.Events;
public class DeviceUpdatedEvent : DomainEventBase
{
  public DeviceUpdatedEvent(Device updatedDevice)
  {
    UpdatedDevice = updatedDevice;
  }

  public Device UpdatedDevice { get; }
}
