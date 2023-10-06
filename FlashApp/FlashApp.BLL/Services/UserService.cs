using FlashApp.BLL.Models.AddModels;
using FlashApp.BLL.Models.UpdateModels;
using FlashApp.DAL.Entities;
using FlashApp.DAL.Repositories.Interfaces;
using AutoMapper;
using FlashApp.BLL.Services.Interfaces;
using FlashApp.BLL.Models;
using FlashApp.BLL.Exceptions;

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
        public async Task<Guid> AddUserAsync(AddUserModel model)
        {
            var userList =  await _userRepository.GetAllAsync();
            if(userList.FirstOrDefault(x=>x.Username==model.Username) is not null)
            {
                throw new RegisterException();
            }
            var addUser = _mapper.Map<User>(model);
            return await _userRepository.AddAsync(addUser);
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
        public async Task<UserModel> GetUserByUsernameAsync(string username)
        {
            var wantedUser = await _userRepository.GetUserByUsernameAsync(username);
            if(wantedUser is null)
            {
                throw new Exception();
            }
            return _mapper.Map<UserModel>(wantedUser);
        }

    }
}
