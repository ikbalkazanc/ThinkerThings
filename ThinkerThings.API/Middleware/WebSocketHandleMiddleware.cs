using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThinkerThings.API.RTC;
using ThinkerThings.API.RTC.WebSocketHub.Devices;

namespace ThinkerThings.API.Middleware
{
    public class WebSocketHandleMiddleware   
    {
        private readonly RequestDelegate _next;
        private readonly SmartLampWebSocketHub _smartLampWebSocketHub;
        public WebSocketHandleMiddleware(RequestDelegate next, SmartLampWebSocketHub smartLampWebSocketHub)
        {
            _next = next;
            _smartLampWebSocketHub = smartLampWebSocketHub;
        }
        public async Task Invoke(HttpContext context)
        {
            string[] endpoints = context.Request.Path.ToString().Split('/');
            if (endpoints[1] == "ws")
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    if(endpoints[2] == "smartlamp")
                    {
                        if(endpoints[3].All(char.IsDigit) == true)
                             await _smartLampWebSocketHub.Connect(context,Int32.Parse(endpoints[3]));
                    }

                }
                else
                {
                    context.Response.StatusCode = 400;
                }
            }
            else
            {
                await _next(context);
            }
        }
        
    }
}
