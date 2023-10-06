using FlashApp.BLL.Services;
using FlashApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlashApp.Api.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("/profile/{username}")]
        [HttpGet]
        public async Task<IActionResult> Profile([FromRoute] string username)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            return View(user);
        }
    }
}
