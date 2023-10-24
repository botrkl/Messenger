using FlashApp.BLL.Models.AddModels;
using FlashApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace FlashApp.Api.SignalRHub
{
    public class ChatHub:Hub
    {
        private IMessageService _messageService;
        private IUserService _userService;
        public ChatHub(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }
        public async Task Send(string chatId, string userId, string content)
        {
            var messageId = await _messageService.AddMessageAsync(new AddMessageModel() { Chat_id = chatId, User_id = userId, Content = content });
            var message = await _messageService.GetByIdAsync(messageId);
            var username = (await _userService.GetByIdAsync(Guid.Parse(userId))).Username;
            await Clients.All.SendAsync("Receive",message, username);
        }
    }
}
