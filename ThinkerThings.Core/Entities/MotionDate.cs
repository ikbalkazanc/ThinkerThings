using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Common;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.Core.Entities
{
    public class MotionDate : BaseEntity
    {
        public DateTime Date { get; set; }

        public int MotionSensorId { get; set; }
        public MotionSensor MotionSensor { get; set; }
    }
}
