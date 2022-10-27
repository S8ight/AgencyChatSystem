using DAL.Models;
using Microsoft.AspNetCore.SignalR;

namespace BLL.Hubs;

public class ChatHub : Hub
{
    public async Task Send(Message message)
    {
        await Clients.All.SendAsync("receiveMessage", message);
    }
    
}