﻿using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Common;
using ThinkerThings.Core.Contracts;

namespace ThinkerThings.Core.Entities.Devices
{
    public class AirConditioner :  Device 
    {
        public bool isOpen { get; set; }
        public int Tempature { get; set; }
        public int FanSpeed { get; set; }

    }
}
