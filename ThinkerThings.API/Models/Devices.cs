using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.API.Models
{
    public class Devices
    {
        public IEnumerable<SmartLamp> SmartLamps { get; set; }
        public IEnumerable<MotionSensor> MotionSensors { get; set; }
        public IEnumerable<AirConditioner> AirConditioners { get; set; }
    }
}
