using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
     //   public async Task SendMessageAsync(string message, string groupName,IEnumerable<string> connectionIds)
       // public async Task SendMessageAsync(string message,IEnumerable<string> groups)
        public async Task SendMessageAsync(string message,string groupName)
        {
            // await Clients.All.SendAsync("receiveMessage",message);

            // Client Türleri 
            #region Caller 
            // Caller 
            // Gönderen Bilgileri Sadece Kendim Almak İstiyorsam Caller Methodunu Kullanmalıyız
            // await Clients.Caller.SendAsync("receiveMessage", message);

            #endregion

            #region Other

            // servere Mesaj Gönderen Kişi Dışında Herkese Mesaj Gider 
            //  await Clients.Others.SendAsync("receiveMessage", message);

            #endregion

            #region Özelleştirilmiş Client Methodlar
            #region AllExcept
            // Belirtilen Clintlerden Hariç Tüm Clintleri Mesaj Gönderir!
            // await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Client
            // Sadece Belirli Bir Clintlere Veri İletir
            //await Clients.Client(connectionIds.FirstOrDefault()).SendAsync("receiveMessage", message);
            #endregion
            #region Clients
            // Burada ise Sadece Bellirtilenlere Veri İletir (Örenegin WhatsApp Gruplarında Seçilen Kişilere Mesaj Gönder )
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Group
            // Belirtilen Gruptaki Tüm Clientlere Bildiride Bulunur!
            // Gruplar Oluşturulmalı ve Clientler Gruplara Subscribe Olmalıdır!
            //  await Clients.Group(groupName).SendAsync("receiveMessage", message);

            #endregion

            #region GroupExcept
            // Belirtilen Gruptaki , Belirtilen clientler dışındaki tüm clientlere mesaj iletmemizi Saglar
           // await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region 
            // Birden Cok Gruptaki Clientlere bildiride bulunmamızı Saglar
            // await Clients.Groups(groups).SendAsync("receiveMessage", message);
            #endregion

            #region OthersInGroup
            // Bildiride Bulunan Client haricinde gruptaki tüm  Clientlere Bildiride Bulunur
            await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion


            #region User
            // Sadece Authentication Olan Kişi Erisebilir
            #endregion 
            #region Users
            // Sadece Authentication Olan Kişiler Erisebilir
            #endregion

            #endregion
        }

        // ConnectionId Almak için
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        // Groups Oluşturmak için
        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }


    }
}
