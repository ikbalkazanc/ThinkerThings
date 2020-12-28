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

namespace ThinkerThings.API.Middleware
{
    public class WebSocketHandleMiddleware   
    {
        private readonly RequestDelegate _next;
        private readonly WebsocketHub _websocketHub;
        public WebSocketHandleMiddleware(RequestDelegate next,WebsocketHub hub)
        {
            _next = next;
            _websocketHub = hub;
        }
        public async Task Invoke(HttpContext context)
        {
            string[] endpoints = context.Request.Path.ToString().Split('/');
            if (endpoints[1] == "ws")
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    if(endpoints[2] == "gateway")
                    {
                        if(endpoints[3].All(char.IsDigit) == true)
                             await _websocketHub.Connect(context,Int32.Parse(endpoints[3]));
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
