using FlashApp.DAL.Entities;

namespace FlashApp.BLL.Models
{
    public class ChatModel
    {
        public string Id { get; set; }
        public ICollection<Message> messages { get; set; }
    }
}
