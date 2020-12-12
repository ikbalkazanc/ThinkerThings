using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.DTOs.Common;

namespace ThinkerThings.Core.DTOs.Devices.AirConditionerDto
{
    class AirConditionerDto : DeviceDTO
    {
        public bool isOpen { get; set; }
        public int Tempature { get; set; }
        public int FanSpeed { get; set; }
    }
}
