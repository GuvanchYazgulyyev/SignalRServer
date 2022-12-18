using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRServer.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> strings);
        Task UserLeaverd(string connectionId);
        Task UserJoined(string connectionId);
    }
}
