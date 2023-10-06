using AutoMapper;
using FlashApp.BLL.Models;
using FlashApp.BLL.Models.AddModels;
using FlashApp.DAL.Entities;

namespace FlashApp.BLL.Mapping
{
    public class UserMapperProfile:Profile
    {
        public UserMapperProfile()
        {
            CreateMap<AddUserModel, User>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Nickname, opt => opt.MapFrom(src => src.Nickname ?? src.Username))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<User, UserModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Nickname, opt => opt.MapFrom(src => src.Nickname))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
