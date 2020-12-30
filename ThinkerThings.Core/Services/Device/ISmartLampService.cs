using ThinkerThings.Core.Entities.Devices;
using ThinkerThings.Core.Services.Common;

namespace ThinkerThings.Core.Services.Device
{
    public interface ISmartLampService : IService<SmartLamp>, IDeviceService<SmartLamp>
    {
    }
}
