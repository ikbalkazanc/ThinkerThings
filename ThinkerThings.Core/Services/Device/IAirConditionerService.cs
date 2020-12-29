using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities.Devices;
using ThinkerThings.Core.Services.Common;

namespace ThinkerThings.Core.Services.Device
{
    public interface IAirConditionerService : IService<AirConditioner> , IDeviceService<AirConditioner>
    {
    }
}
