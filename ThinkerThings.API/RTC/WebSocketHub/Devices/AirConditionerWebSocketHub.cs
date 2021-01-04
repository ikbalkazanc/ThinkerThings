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
    public class AirConditionerWebSocketHub : WebSocketDevice, IAirConditionerWebSocketHub
    {
        private readonly IAirConditionerService _airConditionerService;
        private readonly IHubContext<AirConditionerHub> _airConditionerHub;
        public AirConditionerWebSocketHub(IHubContext<AirConditionerHub> hubContext, IAirConditionerService smartLampService)
        {
            _airConditionerHub = hubContext;
            _airConditionerService = smartLampService;
            //_manager = new WebSocketMessageManager(hubContext);
        }
        public async Task GetTempature(RtcMessage message)
        {
            var websocket = WebSocketsClients.FirstOrDefault(x => x.Key == message.DeviceId);
            if (websocket.Value != null)
            {
                message.Command.type = "AIRCONDITIONER_GET_TEMPATURE";
                var command = JsonConvert.SerializeObject(message);
                var buffer = Encoding.ASCII.GetBytes(command);
                await websocket.Value.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        public async Task SetSpeed(RtcMessage message)
        {
            var websocket = WebSocketsClients.FirstOrDefault(x => x.Key == message.DeviceId);
            if (websocket.Value != null)
            {
                message.Command.type = "AIRCONDITIONER_SET_SPEED";
                var command = JsonConvert.SerializeObject(message);
                var buffer = Encoding.ASCII.GetBytes(command);
                await websocket.Value.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        public async Task ToggleAirConditioner(RtcMessage message)
        {
            var websocket = WebSocketsClients.FirstOrDefault(x => x.Key == message.DeviceId);
            if (websocket.Value != null)
            {
                message.Command.type = "AIRCONDITIONER_TOGGLE";
                var command = JsonConvert.SerializeObject(message);
                var buffer = Encoding.ASCII.GetBytes(command);
                await websocket.Value.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        public override async Task Connect(HttpContext context, int DeviceId)
        {
            var lamp = await _airConditionerService.GetByIdAsync(DeviceId);
            if (lamp != null)
                await base.Connect(context, DeviceId);

        }

    }
}
