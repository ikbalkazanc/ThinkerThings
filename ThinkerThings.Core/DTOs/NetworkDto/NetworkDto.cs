using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.DTOs.Common;

namespace ThinkerThings.Core.DTOs.NetworkDto
{
    public class NetworkDto : BaseDTO
    {
        public string SSID { get; set; }
        public string Password { get; set; }
    }
}
