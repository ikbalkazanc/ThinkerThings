using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkerThings.API.Models
{
    public class RtcMessage
    {
        public string signalrConnectionId { get; set; }
        public int GatewayId { get; set; }
        public int DeviceId { get; set; }
        public Command Command { get; set; }
    }
}
