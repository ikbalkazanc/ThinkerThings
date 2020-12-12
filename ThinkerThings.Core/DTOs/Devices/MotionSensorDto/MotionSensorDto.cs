using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.DTOs.Common;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.Core.DTOs.Devices.MotionSensorDto
{
    public class MotionSensorDto : DeviceDTO
    {
        public bool isAnyMotion { get; set; }
        public ICollection<MotionDate> MotionDate { get; set; }
    }
}
