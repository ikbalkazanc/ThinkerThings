using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using ThinkerThings.API.Models;

namespace ThinkerThings.API.RTC
{
    public class WebsocketHub
    {
        private readonly WsListener wsListener;
        public static ConcurrentDictionary<int, WebSocket> WebSocketsClients = new ConcurrentDictionary<int, WebSocket>();
        private readonly IHubContext<MyHub> _hub;
        public WebsocketHub(IHubContext<MyHub> hub)
        {
            wsListener = new WsListener(hub);
            _hub = hub;
        }
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
        public async Task ToggleLamp(RtcMessage command)
        {
            var websocket = WebSocketsClients.FirstOrDefault(x => x.Key == command.GatewayId);
            if (websocket.Value != null)
            {
                command.Command.type = "BUTTON_TOGGLE";
                var message = JsonConvert.SerializeObject(command);
                var buffer = Encoding.ASCII.GetBytes(message);
                await websocket.Value.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        public async Task GetAllDeviceStatusFromGateway(RtcMessage command)
        {
            var websocket = WebSocketsClients.FirstOrDefault(x => x.Key == command.GatewayId);
            if (websocket.Value != null)
            {
                command.Command.type = "GET_ALL_DEVICES_STATUS";
                var message = JsonConvert.SerializeObject(command);
                var buffer = Encoding.ASCII.GetBytes(message);
                await websocket.Value.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        public async Task Connect(HttpContext context, int GatewayId)
        {
            WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
            WebSocketsClients.TryAdd(GatewayId, webSocket);
            await OnWebSocketConnectedAsync();
            await wsListener.Listener(context, webSocket);

        }
        public async Task<bool> Disconnect(int id)
        {
            var toBeRemoved = WebSocketsClients.FirstOrDefault(x => x.Key == id);
            if (toBeRemoved.Value != null)
            {
                await toBeRemoved.Value.CloseAsync(WebSocketCloseStatus.Empty, "close", CancellationToken.None);
                WebSocketsClients.TryRemove(toBeRemoved);
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
