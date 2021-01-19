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
    public class SmartLampWebSocketHub : WebSocketDevice, ISmartLampWebSocketHub
    {
        private readonly ISmartLampService _smartLampService;
        private readonly IHubContext<SmartLampHub> _smartLampHub;
        private readonly ILogger<SmartLampWebSocketHub> _logger;
        public SmartLampWebSocketHub(IHubContext<AirConditionerHub> conditionerHubContext, ILogger<SmartLampWebSocketHub> logger, IHubContext<SmartLampHub> lampHubContext, ISmartLampService smartLampService, IAirConditionerService airConditionerService)
        {
            _smartLampHub = lampHubContext;
            _smartLampService = smartLampService;
            _manager = new WebSocketMessageManager(lampHubContext, conditionerHubContext);
            _logger = logger;
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
            _logger.LogWarning("Connect to number " + DeviceId + " smart lamp");
            string devices = "";
            foreach (var item in WebSocketsClients)
            {
                devices += item.Key.ToString() + " - ";
            }
            _logger.LogWarning("Devices :  " + devices);
            var lamp = await _smartLampService.GetByIdAsync(DeviceId);

            if (lamp != null)
            {
                await _smartLampService.Alive(DeviceId);
                await base.Connect(context, DeviceId);
            }

        }
        public override async Task<bool> Disconnect(int id)
        {
            _logger.LogWarning("Disconnect to number " + id + " smart lamp");
            string devices = "";
            foreach (var item in WebSocketsClients)
            {
                devices += item.Key.ToString() + " - ";
            }
            _logger.LogWarning("Kaldırıldı Devices :  " + devices);
            await _smartLampService.Kill(id);
            return await base.Disconnect(id);
        }
        public override Task log(string log)
        {
            _logger.LogWarning(log);
            return base.log(log);
        }

    }
}
