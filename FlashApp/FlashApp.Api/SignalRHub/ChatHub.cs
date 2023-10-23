using Microsoft.AspNetCore.SignalR;

namespace FlashApp.Api.SignalRHub
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string user, string message)
        {
            //save in db
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
