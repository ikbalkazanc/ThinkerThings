using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Common;
using ThinkerThings.Core.Contracts;

namespace ThinkerThings.Core.Entities.Devices
{
    public class MotionSensor : Device
    { 
        public bool isAnyMotion { get; set; }
        public ICollection<MotionDate> MotionDate { get; set; }

    }
}
