using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThinkerThings.API.RTC.WebSocketHub
{
    public class WebSocketDevice : IWebSocketDevice
    {
        public static Dictionary<int, WebSocket> WebSocketsClients = new Dictionary<int, WebSocket>();
        protected WebSocketMessageManager _manager;
        public async Task SendAll(string message)
        {
            var buffer = new byte[(message.Length + 1) * 4];
            buffer = Encoding.ASCII.GetBytes(message);
            foreach (var item in WebSocketsClients)
            {
                await item.Value.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        public async Task SendByIdToWebsocketSide(int id, string message)
        {
            var websocket = WebSocketsClients.FirstOrDefault(x => x.Key == id);
            if (websocket.Value != null)
            {
                var buffer = Encoding.ASCII.GetBytes(message);
                await websocket.Value.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        private async Task Listener(int deviceId, WebSocket webSocket)
        {
            try
            {
                var buffer = new byte[50];
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                await log("girdik");
                await _manager.ReceiveNewMessage(System.Text.Encoding.UTF8.GetString(buffer).Substring(0, FindZeroIndex(buffer)));
                await log("giriyoruz");
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);

                while (!result.CloseStatus.HasValue)
                {
                    buffer = new byte[50];
                    await log("döüyoruz 1");
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    await log("dönüyoruz 2");
                    await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                    await _manager.ReceiveNewMessage(System.Text.Encoding.UTF8.GetString(buffer).Substring(0, FindZeroIndex(buffer)));
                }

                await Disconnect(deviceId);

                await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
            catch (Exception ex)
            {
                await log(ex.Message);
            }
        }
        private int FindZeroIndex(byte[] buffer)
        {
            int i = 0;
            while (buffer[i] != 0)
                i++;
            return i;
        }
        public virtual async Task log(string log)
        {

        }

        public virtual async Task Connect(HttpContext context, int DeviceId)
        {
            WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
            var toBeAdd = WebSocketsClients.FirstOrDefault(x => x.Key == DeviceId);
            if (toBeAdd.Value != null)
            {
                WebSocketsClients.Remove(DeviceId);
            }
            WebSocketsClients.Add(DeviceId, webSocket);
            await OnWebSocketConnectedAsync();
            await Listener(DeviceId, webSocket);

        }
        public virtual async Task<bool> Disconnect(int id)
        {
            var toBeRemoved = WebSocketsClients.FirstOrDefault(x => x.Key == id);
            if (toBeRemoved.Value != null)
            {
                WebSocketsClients.Remove(id);
                await OnWebSocketDisconnectedAsync();
                return true;
            }

            return false;
        }

        public Task OnWebSocketConnectedAsync()
        {

            return Task.CompletedTask;
        }
        public Task OnWebSocketDisconnectedAsync()
        {
            return Task.CompletedTask;

        }

    }
}
