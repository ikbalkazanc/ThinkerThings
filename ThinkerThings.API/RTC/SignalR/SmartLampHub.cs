using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ThinkerThings.API.Models;
using ThinkerThings.API.RTC.SignalR.Contracts;
using ThinkerThings.API.RTC.WebSocketHub.Devices;

namespace ThinkerThings.API.RTC.SignalR
{
    public class SmartLampHub : HubService, ISmartLampHub
    {
        private readonly SmartLampWebSocketHub _smartLampWebSocketHub;
        public SmartLampHub(SmartLampWebSocketHub smartLampWebSocketHub)
        {
            _smartLampWebSocketHub = smartLampWebSocketHub;
        }
        public async Task ToggleLamp(string message)
        {
            RtcMessage newMessage = new RtcMessage();
            newMessage = JsonConvert.DeserializeObject<RtcMessage>(message);
            await _smartLampWebSocketHub.ToggleLamp(newMessage);
        }

    }
}
