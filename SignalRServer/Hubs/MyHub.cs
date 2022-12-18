using Microsoft.AspNetCore.SignalR;
using SignalRServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRServer.Hubs
{
    public class MyHub : Hub<IMessageClient>
    {
        static List<string> clients=new List<string>();
        //public async Task SendMessageAsync(string message)
        //{
        //    await Clients.All.SendAsync("receiverMessage", message);
        //}

        // Sistemde .Baglantı Gerceklestigi Zaman Tetiklenecek
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            // Clientleri Haberdar Et
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined", Context.ConnectionId);

            // Interface den referans Aldık
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
        }

        // Varolan bie baglantı koptugunda Tetiklenecek
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            clients.Remove(Context.ConnectionId);
            // Clientleri Haberdar Et
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaverd(Context.ConnectionId);
        }
    }
}
