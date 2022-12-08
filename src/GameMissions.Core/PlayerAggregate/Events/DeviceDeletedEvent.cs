using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMissions.SharedKernel;

namespace GameMissions.Core.PlayerAggregate.Events;
public class DeviceDeletedEvent : DomainEventBase
{
  public DeviceDeletedEvent(Device device)
  {
    Device = device;
  }

  public Device Device { get; }
}
