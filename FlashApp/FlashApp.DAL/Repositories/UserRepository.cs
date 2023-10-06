using FlashApp.DAL.Context;
using FlashApp.DAL.Entities;
using FlashApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlashApp.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private MessengerDbContext _dbContext;
        public UserRepository(MessengerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User?> GetUserByCredentialsAsync(string username, string password)
        {
            var searchedEntity = await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
            return searchedEntity;
        }
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var searchedEntity = await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Username == username);
            return searchedEntity;
        }
    }
}
