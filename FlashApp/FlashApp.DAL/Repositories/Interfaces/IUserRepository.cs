using FlashApp.DAL.Entities;

namespace FlashApp.DAL.Repositories.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
        public Task<User?> GetUserByCredentialsAsync(string username, string password);
        public Task<User?> GetUserByUsernameAsync(string username);
    }
}
