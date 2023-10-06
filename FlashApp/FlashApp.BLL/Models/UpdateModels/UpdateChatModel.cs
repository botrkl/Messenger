using FlashApp.DAL.Entities;

namespace FlashApp.BLL.Models.UpdateModels
{
    public class UpdateChatModel
    {
        public string Id { get; set; }
        public ICollection<Message> messages { get; set; }
    }
}
