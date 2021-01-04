using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkerThings.API.Models;

namespace ThinkerThings.API.RTC.WebSocketHub.Contracts
{
    public interface ISmartLampWebSocketHub
    {
        Task ToggleLamp(RtcMessage message);
    }
}
