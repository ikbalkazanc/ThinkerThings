using ThinkerThings.Core.Common;

namespace ThinkerThings.Core.Entities.Devices
{
    public class AirConditioner : Device
    {
        public bool isOpen { get; set; }
        public int Tempature { get; set; }
        public int FanSpeed { get; set; }

    }
}
