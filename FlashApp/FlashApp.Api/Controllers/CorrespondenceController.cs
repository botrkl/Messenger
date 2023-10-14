using FlashApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlashApp.Api.Controllers
{
    [Authorize]
    public class CorrespondenceController : Controller
    {
        private readonly IJwtService _jwtService;
        private readonly IChatService _chatService;
        public CorrespondenceController(IJwtService jwtService, IChatService chatService)
        {
            _jwtService = jwtService;
            _chatService = chatService;
        }

        [Route("/chats")]
        [HttpGet]
        public IActionResult Chats()
        {
            return View();
        }
        
        [Route("/chat/{chatId}")]
        [HttpGet]
        public async Task<IActionResult> Chat([FromRoute] Guid chatId)
        {
            var chat = await _chatService.GetChatByIdWithUsersAndMessegesAsync(chatId);
            return View(chat);
        }

        [Route("/send-message")]
        public async Task<IActionResult> SendMessageToUser([FromQuery] Guid id)
        {
            var token = HttpContext.Session.GetString("Token");
            var currentUserId = _jwtService.GetId(token);
            if (currentUserId.Equals(id))
            {
                return Redirect("/chats/");
            }
            var chatId = await _chatService.GetChatByUsersIdAsync(currentUserId, id);
            return Redirect($"/chat/{chatId}");
        }
    }
}
