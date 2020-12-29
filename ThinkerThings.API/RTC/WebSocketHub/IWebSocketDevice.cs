using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using ThinkerThings.API.RTC.SignalR;
using ThinkerThings.Core.Common;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.API.RTC.WebSocketHub
{
    public interface IWebSocketDevice
    {
        Task SendAll(string message);
        Task SendByIdToWebsocketSide(int id, string message);
        Task Connect(HttpContext context, int GatewayId);
        Task<bool> Disconnect(int id);
    }
}
