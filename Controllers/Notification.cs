using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalIrNotifications.Hubs;

namespace SignalIrNotifications.Controllers
{
    [ApiController]
    [Route("api/v1/notifiaction")]
    public class Notification(IHubContext<NotificationHub> hubContext) : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext = hubContext;

        [HttpPost]
        public async Task<IActionResult> Send(string message)
        {
            await _hubContext.Clients.All.SendAsync("sendMessage",message);

            return Ok( );
        }

        [HttpPost("newnotification")] 
        public async Task<IActionResult> NewNotification(string room, string message)
        {
            await _hubContext.Clients.Group(room).SendAsync("messageGroup", message);

            return Ok();
        }
    }
}
