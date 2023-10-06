using AutoMapper;
using FlashApp.BLL.Models.AddModels;
using FlashApp.BLL.Models.UpdateModels;
using FlashApp.BLL.Models;
using FlashApp.DAL.Entities;
using FlashApp.DAL.Repositories.Interfaces;
using FlashApp.BLL.Services.Interfaces;

namespace FlashApp.BLL.Services
{
    public class MessageService:IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMapper mapper, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
        }
        public async Task AddMessageAsync(AddMessageModel model)
        {
            var addMessage = _mapper.Map<Message>(model);
            await _messageRepository.AddAsync(addMessage);
        }
        public async Task DeleteMessageAsync(Guid id)
        {
            await _messageRepository.DeleteAsync(id);
        }
        public async Task<MessageModel> GetByIdAsync(Guid id)
        {
            var wantedMessage = await _messageRepository.GetByIdAsync(id);
            return _mapper.Map<MessageModel>(wantedMessage);
        }
        public async Task UpdateMessageAsync(UpdateMessageModel model)
        {
            var tempMessage = await _messageRepository.GetByIdAsync(Guid.Parse(model.Id));
            _mapper.Map(model, tempMessage);
            await _messageRepository.UpdateAsync(tempMessage);
        }
    }
}
