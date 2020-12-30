using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using ThinkerThings.API.Models;
using ThinkerThings.API.RTC.WebSocketHub.Devices;

namespace ThinkerThings.API.RTC.SignalR
{
    public class MyHub : Hub
    {
        private static ConcurrentDictionary<string, int> UserClients = new ConcurrentDictionary<string, int>();
        private readonly SmartLampWebSocketHub _smartLampWebSocketHub;
        public MyHub(SmartLampWebSocketHub smartLampWebSocketHub)
        {
            _smartLampWebSocketHub = smartLampWebSocketHub;
        }
        public async Task GetMessages()
        {
            await Clients.All.SendAsync("ReceivesMessage", "Messages22");
        }

        public async Task SendDeviceId(string id)
        {
            await _smartLampWebSocketHub.SendAll("Burda Devicenin tamamı var" + id);
        }
        public async Task ToggleLamp(RtcMessage message)
        {
            await _smartLampWebSocketHub.ToggleLamp(message);
        }
        public override Task OnConnectedAsync()
        {
            UserClients.TryAdd(Context.ConnectionId, -1);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            int i = -1;
            UserClients.TryRemove(Context.ConnectionId, out i);
            return base.OnDisconnectedAsync(exception);
        }

    }
}
