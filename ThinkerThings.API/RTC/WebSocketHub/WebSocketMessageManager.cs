using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using ThinkerThings.API.Models;
using ThinkerThings.API.RTC.SignalR;

namespace ThinkerThings.API.RTC.WebSocketHub
{
    public class WebSocketMessageManager
    {
        private readonly IHubContext<AirConditionerHub> _airConditionerHub;
        private readonly IHubContext<SmartLampHub> _smartLampHub;
        public WebSocketMessageManager(IHubContext<SmartLampHub> smartLampHub, IHubContext<AirConditionerHub> airConditionerHub)
        {
            _airConditionerHub = airConditionerHub;
            _smartLampHub = smartLampHub;
        }
        public async Task ReceiveNewMessage(string message)
        {
            RtcMessage data;
            try
            {
                data = JsonConvert.DeserializeObject<RtcMessage>(message);

                if (data.Command.type == "AIRCONDITIONER_GET_TEMPATURE")
                {
                    await _airConditionerHub.Clients.Client(data.signalrConnectionId).SendAsync("tempature", data.Command.tempature);
                }
            }
            catch
            {
                return;
            }

        }
    }
}
