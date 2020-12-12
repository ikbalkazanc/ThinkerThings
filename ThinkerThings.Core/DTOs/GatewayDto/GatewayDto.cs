using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.DTOs.Common;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.Core.DTOs.GatewayDto
{
    public class GatewayDto : BaseDTO
    {
        public bool isAlive { get; set; }
        public int NetworkId { get; set; }
        public int UserId { get; set; }

        public ICollection<AirConditioner> AirConditioners { get; set; }
        public ICollection<MotionSensor> MotionSensors { get; set; }
        public ICollection<SmartLamp> SmartLamps { get; set; }

    }
}
