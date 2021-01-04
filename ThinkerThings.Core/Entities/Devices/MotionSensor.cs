using System.Collections.Generic;
using ThinkerThings.Core.Common;

namespace ThinkerThings.Core.Entities.Devices
{
    public class MotionSensor : Device
    {
        public bool isAnyMotion { get; set; }
        public ICollection<MotionDate> MotionDate { get; set; }

    }
}
