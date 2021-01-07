using Newtonsoft.Json;
using System.Threading.Tasks;
using ThinkerThings.API.Models;
using ThinkerThings.API.RTC.SignalR.Contracts;
using ThinkerThings.API.RTC.WebSocketHub.Devices;

namespace ThinkerThings.API.RTC.SignalR
{
    public class AirConditionerHub : HubService, IAirConditionerHub
    {
        private readonly AirConditionerWebSocketHub _airConditionerWebSocketHub;
        public AirConditionerHub(AirConditionerWebSocketHub airConditionerWebSocketHub)
        {
            _airConditionerWebSocketHub = airConditionerWebSocketHub;
        }
        public async Task GetTempature(string message)
        {
            RtcMessage newMessage = new RtcMessage();
            newMessage = JsonConvert.DeserializeObject<RtcMessage>(message);
            await _airConditionerWebSocketHub.GetTempature(newMessage);
        }

        public async Task SetSpeed(string message)
        {
            RtcMessage newMessage = new RtcMessage();
            newMessage = JsonConvert.DeserializeObject<RtcMessage>(message);
            await _airConditionerWebSocketHub.SetSpeed(newMessage);
        }
        public async Task GetSpeed(string message)
        {
            RtcMessage newMessage = new RtcMessage();
            newMessage = JsonConvert.DeserializeObject<RtcMessage>(message);
            await _airConditionerWebSocketHub.GetSpeed(newMessage);
        }

        public async Task ToggleAirConditioner(string message)
        {
            RtcMessage newMessage = new RtcMessage();
            newMessage = JsonConvert.DeserializeObject<RtcMessage>(message);
            await _airConditionerWebSocketHub.ToggleAirConditioner(newMessage);
        }
    }
}
