using FlashApp.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlashApp.Api.Controllers
{
    [Authorize]
    public class CorrespondenceController : Controller
    {
        [Route("/chats")]
        [HttpGet]
        public IActionResult Chats()
        {
            return View();
        }
        
        [Route("/chat/{id}")]
        [HttpGet]
        public IActionResult Chats(string chatId)
        {
            return View();
        }

        [Route("/send-message")]
        public IActionResult SendMessageToUser([FromQuery] string username)
        {
            //take userid by username and current userid by jwt token
            //find chat where exist only this two user
            //if no chat create
            return View();
        }
    }
}
