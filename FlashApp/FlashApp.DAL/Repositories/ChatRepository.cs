using FlashApp.DAL.Context;
using FlashApp.DAL.Entities;
using FlashApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

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
            var chatList = await _dbContext.Chat
                .Where(chat => chat.ChatUsers.Any(x => x.UserId == userId))
                .Include(x => x.Messages)
                .Include(x => x.ChatUsers)
                .ThenInclude(x => x.User)
                .ToListAsync();

            return chatList;
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
        public async Task<Chat> GetChatByIdWithUsersAndMessegesAsync(Guid chatId)
        {
            var chat = await _dbContext.Chat
                .Where(chat => chat.Id == chatId)
                .Include(x => x.Messages)
                .Include(x => x.ChatUsers)
                .ThenInclude(x => x.User)
                .FirstAsync();

            return chat;
        }
    }
}
