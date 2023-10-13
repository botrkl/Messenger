using FlashApp.DAL.Entities;

namespace FlashApp.DAL.Repositories.Interfaces
{
    public interface IChatRepository:IBaseRepository<Chat>
    {
        public  Task<IEnumerable<Chat>> GetChatsByUserIdAsync(Guid userId);
        public Task<Guid?> GetChatByUsersIdAsync(Guid currentUserId, Guid userId);
        public Task<Chat> GetChatByIdWithUsersAndMessegesAsync(Guid chatId);
    }
}
