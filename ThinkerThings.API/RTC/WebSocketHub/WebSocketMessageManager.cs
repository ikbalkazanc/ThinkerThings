using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //var data = JsonConvert.DeserializeObject<RtcMessage>(message);
            if("data.Command.type" == "BUTTON_TOGGLE")
            {
                
            } 
        }
    }
}
