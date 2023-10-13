using AutoMapper;
using FlashApp.BLL.Models.AddModels;
using FlashApp.BLL.Models.UpdateModels;
using FlashApp.BLL.Models;
using FlashApp.DAL.Entities;
using FlashApp.DAL.Repositories.Interfaces;
using FlashApp.BLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace FlashApp.BLL.Services
{
    public class ChatService:IChatService
    {
        private readonly IMapper _mapper;
        private readonly IChatRepository _chatRepository;
        private readonly IChatUserRepository _chatUserRepository;
        public ChatService(IMapper mapper, IChatRepository chatRepository, IChatUserRepository chatUserRepository)
        {
            _mapper = mapper;
            _chatRepository = chatRepository;
            _chatUserRepository = chatUserRepository;
        }
        public async Task<Guid> AddChatAsync(AddChatModel model)
        {
            var addChat = _mapper.Map<Chat>(model);
            return await _chatRepository.AddAsync(addChat);
        }
        public async Task DeleteChatAsync(Guid id)
        {
            await _chatRepository.DeleteAsync(id);
        }
        public async Task<ChatModel> GetByIdAsync(Guid id)
        {
            var wantedChat = await _chatRepository.GetByIdAsync(id);
            return _mapper.Map<ChatModel>(wantedChat);
        }
        public async Task UpdateChatAsync(UpdateChatModel model)
        {
            var tempChat = await _chatRepository.GetByIdAsync(Guid.Parse(model.Id));
            _mapper.Map(model, tempChat);
            await _chatRepository.UpdateAsync(tempChat);
        }
        public async Task<IEnumerable<ChatModel>> GetChatsByUserIdAsync(Guid userId)
        {
            var chats = await _chatRepository.GetChatsByUserIdAsync(userId);
            if (chats.Count()==0)
            {
                return null;
            }
            var c  = chats.Where(x=>x.Messages.Count()>0).OrderByDescending(chat => chat.Messages.Max(message => message.Creation_Time)).ToList();
            var b = chats.Where(x => x.Messages.Count() == 0).ToList();

            c.AddRange(b);

            var chatModels = _mapper.Map<IEnumerable<ChatModel>>(chats);
            return chatModels;
        }
        public async Task<Guid> GetChatByUsersIdAsync(Guid currentUserId, Guid userId)
        {
            var chatId = await _chatRepository.GetChatByUsersIdAsync(currentUserId, userId);
            if(chatId != null && chatId != Guid.Empty)
            {
                return (Guid)chatId;
            }
            else
            {
                var newChatId = await _chatRepository.AddAsync(new Chat());

                await _chatUserRepository.AddAsync(new ChatUser { ChatId = newChatId, UserId = currentUserId });
                await _chatUserRepository.AddAsync(new ChatUser { ChatId = newChatId, UserId = userId });
                
                return newChatId;
            }
        }
        public async Task<ChatModel> GetChatByIdWithUsersAndMessegesAsync(Guid chatId)
        {
            var chat = await _chatRepository.GetChatByIdWithUsersAndMessegesAsync(chatId);
            return _mapper.Map<ChatModel>(chat);
        }
    }
}
