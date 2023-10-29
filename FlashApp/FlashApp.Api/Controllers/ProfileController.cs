using FlashApp.BLL.Exceptions;
using FlashApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlashApp.Api.Controllers
{
    [ApiController]
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
            try
            {
                var user = await _userService.GetUserByUsernameAsync(username);
                return View(user);
            }
            catch (UserDoesNotExistException)
            {
                return View(null);
            }
        }
    }
}
