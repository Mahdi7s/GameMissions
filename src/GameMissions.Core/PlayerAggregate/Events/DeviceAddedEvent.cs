using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.PlayerAggregate.Events;
public class DeviceAddedEvent : DomainEventBase
{
  public DeviceAddedEvent(Device newDevice)
  {
    NewDevice = newDevice;
  }

  public Device NewDevice { get; }
}
