using AutoMapper;
using FlashApp.Api.Models;
using FlashApp.BLL.Exceptions;
using FlashApp.BLL.Models.AddModels;
using FlashApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlashApp.Api.Controllers
{
    public class AuthController : Controller
    {
        private IAuthenticationService _authenticationService;
        private IJwtService _jwtService;
        private IConfiguration _configuration;
        private IUserService _userService;
        private IMapper _mapper;

        public AuthController(IAuthenticationService authenticationService, IJwtService jwtService, IConfiguration configuration, IUserService userService,IMapper mapper)
        {
            _authenticationService = authenticationService;
            _jwtService = jwtService;
            _configuration = configuration;
            _userService = userService;
            _mapper = mapper;
        }

        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/login")]
        [HttpGet]
        public  IActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(login);
            }
            try
            {
                var userId = await _authenticationService.AuthenticateAsync(login.Username, login.Password);
                var token = _jwtService.CreateJWT(userId,_configuration);
                HttpContext.Session.SetString("Token", token);
                return Redirect("/chats");
            }
            catch (AuthException)
            {
                ViewBag.Error = "Wrong username or password!";
                return View();
            }
        }

        [Route("/register")]
        [HttpGet]
        public  IActionResult Register()
        {
            return View();
        }

        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(registerDTO);
            }
            try
            {
                var addUserModel = _mapper.Map<AddUserModel>(registerDTO);
                var userId = await _userService.AddUserAsync(addUserModel);
                var token = _jwtService.CreateJWT(userId, _configuration);
                HttpContext.Session.SetString("Token", token);
                return Redirect("/chats");
            }
            catch(RegisterException e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
    }
}
