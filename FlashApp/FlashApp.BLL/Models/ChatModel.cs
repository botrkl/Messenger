using FlashApp.DAL.Entities;

namespace FlashApp.BLL.Models
{
    public class ChatModel
    {
        public string Id { get; set; }
        public ICollection<UserModel> users { get; set; }
        public ICollection<MessageModel>? messages { get; set; }
    }
}
