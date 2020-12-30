using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using ThinkerThings.API.RTC.SignalR;

namespace ThinkerThings.API.RTC.WebSocketHub
{
    public class WebSocketListener
    {
        private readonly WebSocketMessageManager _manager;
        public WebSocketListener(IHubContext<MyHub> hub)
        {
            _manager = new WebSocketMessageManager(hub);
        }
        public async Task Listener(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            await _manager.ReceiveNewMessage(System.Text.Encoding.UTF8.GetString(buffer).Substring(0, FindZeroIndex(buffer)));
            while (!result.CloseStatus.HasValue)
            {
                buffer = new byte[1024 * 4];
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                await _manager.ReceiveNewMessage(System.Text.Encoding.UTF8.GetString(buffer).Substring(0, FindZeroIndex(buffer)));
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
        public int FindZeroIndex(byte[] buffer)
        {
            int i = 0;
            while (buffer[i] != 0)
                i++;
            return i;
        }
    }
}
