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
        private readonly IHubContext<MyHub> _hub;
        public WebSocketMessageManager(IHubContext<MyHub> hub)
        {
            _hub = hub;
        }
        public async Task ReceiveNewMessage(string message)
        {
            RtcMessage data;
            try
            {
                data = JsonConvert.DeserializeObject<RtcMessage>(message);
            }
            catch (Exception ex)
            {
                return;
            }
            if ("data.Command.type" == "BUTTON_TOGGLE")
            {

            }
        }
    }
}
