using FlashApp.BLL.Models;

namespace FlashApp.Api.Models
{
    public class ChatViewModel
    {
        public ChatModel chat { get; set; }
        public Guid currentUserId { get; set; }
    }
}
