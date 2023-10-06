using FlashApp.BLL.Exceptions;
using FlashApp.BLL.Services.Interfaces;
using FlashApp.DAL.Repositories.Interfaces;

namespace FlashApp.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByCredentialsAsync(username, password);
            if (user is null)
            {
                throw new AuthException();
            }
            return user.Id;
        }
    }
}
