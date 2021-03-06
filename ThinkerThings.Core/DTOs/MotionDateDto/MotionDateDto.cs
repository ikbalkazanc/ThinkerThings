﻿using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.DTOs.Common;

namespace ThinkerThings.Core.DTOs.MotionDateDto
{
    public class MotionDateDto : BaseDTO
    {
        public DateTime Date { get; set; }
        public int MotionSensorId { get; set; }
    }
}
