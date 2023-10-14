using FlashApp.DAL.Context;
using FlashApp.DAL.Entities;
using FlashApp.DAL.Repositories.Interfaces;

namespace FlashApp.DAL.Repositories
{
    public class ChatUserRepository : IChatUserRepository
    {
        private MessengerDbContext _dbContext;
        public ChatUserRepository(MessengerDbContext dbContext) 
        { 
            _dbContext = dbContext; 
        }

        public async Task AddAsync(ChatUser entity)
        {
            await _dbContext.Set<ChatUser>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
