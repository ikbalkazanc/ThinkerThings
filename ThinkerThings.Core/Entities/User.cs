using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Common;
using ThinkerThings.Core.Contracts;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.Core.Entities
{
    public class User : BaseEntity 
    {
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int NetworkId { get; set; }
        public Network Network { get; set; }

        public IEnumerable<AirConditioner> AirConditioners { get; set; }
        public IEnumerable<MotionSensor> MotionSensors { get; set; }
        public IEnumerable<SmartLamp> SmartLamps { get; set; }


    }
}
