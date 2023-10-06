using AutoMapper;
using FlashApp.BLL.Models.AddModels;
using FlashApp.BLL.Models.UpdateModels;
using FlashApp.BLL.Models;
using FlashApp.DAL.Entities;
using FlashApp.DAL.Repositories.Interfaces;
using FlashApp.BLL.Services.Interfaces;

namespace FlashApp.BLL.Services
{
    public class ChatService:IChatService
    {
        private readonly IMapper _mapper;
        private readonly IChatRepository _chatRepository;
        public ChatService(IMapper mapper, IChatRepository chatRepository)
        {
            _mapper = mapper;
            _chatRepository = chatRepository;
        }
        public async Task AddChatAsync(AddChatModel model)
        {
            var addChat = _mapper.Map<Chat>(model);
            await _chatRepository.AddAsync(addChat);
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
    }
}
