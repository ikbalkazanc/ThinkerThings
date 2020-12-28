using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkerThings.API.Models;

namespace ThinkerThings.API.RTC
{
    public class MyHub : Hub
    {
        private static ConcurrentDictionary<string, int> UserClients = new ConcurrentDictionary<string, int>();
        private readonly WebsocketHub _websocketHub;
        public MyHub(WebsocketHub hub)
        {
            _websocketHub = hub;
        }
        public async Task GetMessages()
        {
            await Clients.All.SendAsync("ReceivesMessage", "Messages22");
        }

        public async Task SendDeviceId(string id)
        {
            await _websocketHub.SendAll("Burda Devicenin tamamı var" + id);
        }
        public async Task SendCommand(string command)
        {
            var data = JsonConvert.DeserializeObject<RtcMessage>(command);
            await _websocketHub.SendByIdToWebsocketSide(data.GatewayId, command);
        }
        public async Task ToggleLamp(string command)
        {
            var data = JsonConvert.DeserializeObject<RtcMessage>(command);
            //await _websocketHub.ToggleLamp(data.GatewayId, command);
        }
        public async Task GetAllDeviceStatesFromGateway(string command)
        {
            var data = JsonConvert.DeserializeObject<RtcMessage>(command);
            await _websocketHub.GetAllDeviceStatusFromGateway(data);
        }
        public async Task SetGatewayIdToConnectionId(string id)
        {
            var client =  UserClients.FirstOrDefault(x => x.Key == Context.ConnectionId);
            if(client.Key != null)
            {
                UserClients.TryUpdate(Context.ConnectionId, Int32.Parse(id), Int32.Parse(id));
            }
            
        }
        public override Task OnConnectedAsync()
        {
            UserClients.TryAdd(Context.ConnectionId, -1);
            return base.OnConnectedAsync();
        }
       
        public override Task OnDisconnectedAsync(Exception exception)
        {
            int i = -1;
            UserClients.TryRemove(Context.ConnectionId,out i);
            return base.OnDisconnectedAsync(exception);
        }

    }
}
