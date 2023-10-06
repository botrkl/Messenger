namespace FlashApp.BLL.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<Guid> AuthenticateAsync(string username, string password);
    }
}
