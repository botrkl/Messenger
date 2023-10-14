using FlashApp.DAL.Entities;

namespace FlashApp.DAL.Repositories.Interfaces
{
    public interface IChatUserRepository
    {
        public Task AddAsync(ChatUser entity);
    }
}
