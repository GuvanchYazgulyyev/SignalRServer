using Microsoft.AspNetCore.SignalR;
using SignalRServer.Hubs;
using System.Threading.Tasks;

namespace SignalRServer.Business
{
    public class MyBusiness
    {
        IHubContext<MyHub> _hubContext;

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiverMessage", message);
        }
    }
}
