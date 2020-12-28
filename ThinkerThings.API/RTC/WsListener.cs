using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace ThinkerThings.API.RTC
{
    public class WsListener
    {
        private readonly WebSocketMessageManager _manager;
        public WsListener(IHubContext<MyHub> hub)
        {
            _manager = new WebSocketMessageManager(hub);
        }
        public async Task Listener(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            await _manager.ReceiveNewMessage(System.Text.Encoding.UTF8.GetString(buffer).Substring(0, await FindZeroIndex(buffer)));
            while (!result.CloseStatus.HasValue)
            {
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                await _manager.ReceiveNewMessage(System.Text.Encoding.UTF8.GetString(buffer).Substring(0, await FindZeroIndex(buffer)));
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
        public async Task<int> FindZeroIndex(byte[] buffer)
        {
            int i = 0;
            while (buffer[i] != 0)
                i++;
            return i;
        }
    }
}
