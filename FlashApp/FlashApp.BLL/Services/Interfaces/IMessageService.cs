using FlashApp.BLL.Models.AddModels;
using FlashApp.BLL.Models.UpdateModels;
using FlashApp.BLL.Models;

namespace FlashApp.BLL.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<MessageModel> GetByIdAsync(Guid id);
        public Task DeleteMessageAsync(Guid id);
        public Task<Guid> AddMessageAsync(AddMessageModel model);
        public Task UpdateMessageAsync(UpdateMessageModel model);
    }
}
