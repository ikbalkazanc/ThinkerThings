using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using ThinkerThings.API.RTC.WebSocketHub.Devices;

namespace ThinkerThings.API.Middleware
{
    public class WebSocketHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public WebSocketHandleMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task Invoke(HttpContext context, SmartLampWebSocketHub _smartLampWebSocketHub, AirConditionerWebSocketHub _airConditionerWebSocketHub)
        {
            string[] endpoints = context.Request.Path.ToString().Split('/');
            if (endpoints[1] == "ws")
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    if (endpoints[2] == "smartlamp")
                    {
                        if (endpoints[3].All(char.IsDigit) == true)
                            await _smartLampWebSocketHub.Connect(context, Int32.Parse(endpoints[3]));
                    }
                    if (endpoints[2] == "airconditioner")
                    {
                        if (endpoints[3].All(char.IsDigit) == true)
                            await _airConditionerWebSocketHub.Connect(context, Int32.Parse(endpoints[3]));
                    }

                }
                else
                {
                    context.Response.StatusCode = 400;
                }
            }
            else
            {
                context.Response.StatusCode = 400;
                await _next(context);
            }
        }

    }
}
