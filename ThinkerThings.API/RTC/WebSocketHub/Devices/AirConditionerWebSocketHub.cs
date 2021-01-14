using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AirConditionerWebSocketHub> _logger;
        public AirConditionerWebSocketHub(IHubContext<AirConditionerHub> conditionerHubContext, ILogger<AirConditionerWebSocketHub> logger, IHubContext<SmartLampHub> lampHubContext, ISmartLampService smartLampService, IAirConditionerService airConditionerService)
        {
            _airConditionerHub = conditionerHubContext;
            _airConditionerService = airConditionerService;
            _manager = new WebSocketMessageManager(lampHubContext, conditionerHubContext);
            _logger = logger;
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
            _logger.LogWarning("Connect to number " + DeviceId + " air conditioner");
            string devices = "";
            foreach (var item in WebSocketsClients)
            {
                devices += item.Key.ToString() + " - ";
            }
            _logger.LogWarning("Devices :  " + devices);
            var lamp = await _airConditionerService.GetByIdAsync(DeviceId);
            await _airConditionerService.Alive(DeviceId);
            if (lamp != null)
                await base.Connect(context, DeviceId);

        }
        public override Task<bool> Disconnect(int id)
        {
            _logger.LogWarning("Disonnect to number " + id + " air conditioner");
            string devices = "";
            foreach (var item in WebSocketsClients)
            {
                devices += item.Key.ToString() + " - ";
            }
            _logger.LogWarning("Devices :  " + devices);
            _airConditionerService.Kill(id);
            return base.Disconnect(id);
        }

    }
}
