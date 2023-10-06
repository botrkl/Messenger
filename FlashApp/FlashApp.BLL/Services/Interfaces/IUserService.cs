using FlashApp.BLL.Models.AddModels;
using FlashApp.BLL.Models.UpdateModels;
using FlashApp.BLL.Models;
using FlashApp.DAL.Entities;

namespace FlashApp.BLL.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel> GetByIdAsync(Guid id);
        public Task DeleteUserAsync(Guid id);
        public Task<Guid> AddUserAsync(AddUserModel model);
        public Task UpdateUserAsync(UpdateUserModel model);
        public Task<UserModel> GetUserByUsernameAsync(string username);
    }
}
