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
            if (context.WebSockets.IsWebSocketRequest)
            {
                string[] endpoints = context.Request.Path.ToString().Split('/');
                if (endpoints[1] == "ws")
                {
                    if (endpoints[3].All(char.IsDigit) == true)
                    {
                        if (endpoints[2] == "smartlamp")
                        {
                            await _smartLampWebSocketHub.Connect(context, Int32.Parse(endpoints[3]));
                        }
                        else if (endpoints[2] == "airconditioner")
                        {
                            await _airConditionerWebSocketHub.Connect(context, Int32.Parse(endpoints[3]));
                        }
                        else
                            context.Response.StatusCode = 400;
                    }
                    else
                        context.Response.StatusCode = 400;

                }
                else
                    await _next(context);
            }
            else
            {
                await _next(context);
            }
        }

    }
}
