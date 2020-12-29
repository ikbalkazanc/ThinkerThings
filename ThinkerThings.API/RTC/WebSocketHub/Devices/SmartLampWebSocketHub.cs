using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThinkerThings.API.Models;
using ThinkerThings.API.RTC.SignalR;
using ThinkerThings.Core.Services.Device;

namespace ThinkerThings.API.RTC.WebSocketHub.Devices
{
    public class SmartLampWebSocketHub : WebSocketDevice
    {
        private readonly ISmartLampService _smartLampService;
        public SmartLampWebSocketHub(IHubContext<MyHub> hub, ISmartLampService smartLampService) : base(hub)
        {
            _smartLampService = smartLampService;
        }
        public async Task ToggleLamp(RtcMessage command)
        {
            var websocket = WebSocketsClients.FirstOrDefault(x => x.Key == command.DeviceId);
            if (websocket.Value != null)
            {
                command.Command.type = "BUTTON_TOGGLE";
                var message = JsonConvert.SerializeObject(command);
                var buffer = Encoding.ASCII.GetBytes(message);
                await websocket.Value.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        public override async Task Connect(HttpContext context, int DeviceId)
        {
            var lamp = await _smartLampService.GetByIdAsync(DeviceId);
            if (lamp != null)
                await base.Connect(context, DeviceId);

        }

    }
}
