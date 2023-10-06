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
            //Print all chats like list sorted by last messege time
            return View();
        }
        
        [Route("/chats/{id}")]
        [HttpGet]
        public IActionResult Chats(string chatId)
        {
            //open specific chat in part of view
            return View();
        }
    }
}
