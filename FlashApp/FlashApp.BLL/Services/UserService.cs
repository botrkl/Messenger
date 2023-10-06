using FlashApp.BLL.Models.AddModels;
using FlashApp.BLL.Models.UpdateModels;
using FlashApp.DAL.Entities;
using FlashApp.DAL.Repositories.Interfaces;
using AutoMapper;
using FlashApp.BLL.Services.Interfaces;
using FlashApp.BLL.Models;

namespace FlashApp.BLL.Services
{
    public class UserService:IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper,IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task AddUserAsync(AddUserModel model)
        {
            var addUser = _mapper.Map<User>(model);
            await _userRepository.AddAsync(addUser);
        }
        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }
        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            var wantedUser = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserModel>(wantedUser);
        }
        public async Task UpdateUserAsync(UpdateUserModel model)
        {
            var tempUser = await _userRepository.GetByIdAsync(Guid.Parse(model.Id));
            _mapper.Map(model, tempUser);
            await _userRepository.UpdateAsync(tempUser);
        }
    }
}
