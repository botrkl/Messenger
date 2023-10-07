using FlashApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlashApp.Api.ViewComponents
{
    [ViewComponent(Name = "ChatsViewComponents")]
    public class ChatsViewComponents:ViewComponent
    {
        private IJwtService _jwtService;
        private IChatService _chatService;
        public ChatsViewComponents(IJwtService jwtService, IChatService chatService)
        {
            _jwtService = jwtService;
            _chatService = chatService;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = HttpContext.Session.GetString("Token");
            var userId = _jwtService.GetId(token);
            var chats = await _chatService.GetChatsByUserIdAsync(userId);
            return View("Default", chats);
        }
    }
}
