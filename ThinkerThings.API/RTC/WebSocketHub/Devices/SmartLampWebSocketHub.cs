using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThinkerThings.API.Models;
using ThinkerThings.API.RTC.SignalR;
using ThinkerThings.API.RTC.WebSocketHub.Contracts;
using ThinkerThings.Core.Services.Device;

namespace ThinkerThings.API.RTC.WebSocketHub.Devices
{
    public class SmartLampWebSocketHub : WebSocketDevice, ISmartLampWebSocketHub
    {
        private readonly ISmartLampService _smartLampService;
        private readonly IHubContext<SmartLampHub> _smartLampHub;
        public SmartLampWebSocketHub(IHubContext<AirConditionerHub> conditionerHubContext, IHubContext<SmartLampHub> lampHubContext, ISmartLampService smartLampService, IAirConditionerService airConditionerService)
        {
            _smartLampHub = lampHubContext;
            _smartLampService = smartLampService;
            _manager = new WebSocketMessageManager(lampHubContext, conditionerHubContext);
        }
        public async Task ToggleLamp(RtcMessage message)
        {
            var websocket = WebSocketsClients.FirstOrDefault(x => x.Key == message.DeviceId);
            if (websocket.Value != null)
            {
                message.Command.type = "BUTTON_TOGGLE";
                var command = JsonConvert.SerializeObject(message);
                var buffer = Encoding.ASCII.GetBytes(command);

                await websocket.Value.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        public override async Task Connect(HttpContext context, int DeviceId)
        {
            var lamp = await _smartLampService.GetByIdAsync(DeviceId);
            if (lamp != null)
            {
                await _smartLampService.Alive(DeviceId);
                await base.Connect(context, DeviceId);
                await Disconnect(DeviceId);
            }


        }
        public async Task DisconnectWebsocket(int DeviceId)
        {
            await _smartLampService.Dead(DeviceId);
        }

    }
}
