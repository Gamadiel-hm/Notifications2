using Microsoft.AspNetCore.SignalR;

namespace SignalIrNotifications.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task AddGroup(string room,string usuario)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);

            await Clients.Group(room).SendAsync("joinGroup", $"Join chat: {usuario}");
        }
    }
}
