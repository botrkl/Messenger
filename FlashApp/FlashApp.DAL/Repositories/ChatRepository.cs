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
        public async Task<IEnumerable<Chat>> GetChatsByUserIdAsync(Guid userId)
        {
            return await _dbContext.ChatUser
                .Where(chatUser => chatUser.UserId == userId)
                .Include(chat => chat.Chat.Messages)
                .ThenInclude(chatUser => chatUser.User)
                .Select(chatUser => chatUser.Chat)
                .ToListAsync();
        }
        public async Task<Guid?> GetChatByUsersIdAsync(Guid currentUserId, Guid userId)
        {
            var chat = await _dbContext.ChatUser
                .Where(chatUser => chatUser.UserId == currentUserId || chatUser.UserId == userId)
                .GroupBy(chatUser => chatUser.ChatId)
                .Where(group => group.Count() == 2) 
                .Select(group => group.Key)
                .FirstOrDefaultAsync();

            return chat;
        }
    }
}
