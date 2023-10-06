using FlashApp.DAL.Context;
using FlashApp.DAL.Entities;
using FlashApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlashApp.DAL.Repositories
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        private MessengerDbContext _dbContext;

        public ChatRepository(MessengerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Chat>?> GetChatsByUserIdAsync(Guid userId)
        {
            return await _dbContext.ChatUser
                .Where(chatUser => chatUser.UserId == userId)
                .Select(chatUser => chatUser.Chat)
                .Include(chat => chat.Messages)
                .ThenInclude(chatUser => chatUser.User)
                .ToListAsync();
        }
    }
}
