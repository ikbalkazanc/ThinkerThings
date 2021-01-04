using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using ThinkerThings.API.Models;
using ThinkerThings.API.RTC.WebSocketHub.Devices;

namespace ThinkerThings.API.RTC.SignalR
{
    public class HubService : Hub
    {
        protected static ConcurrentDictionary<string, int> UserClients = new ConcurrentDictionary<string, int>();
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
