using AutoMapper;
using FlashApp.Api.Models;
using FlashApp.BLL.Models.AddModels;

namespace FlashApp.Api.Mapping
{
    public class WebMappingProfile:Profile
    {
        public WebMappingProfile()
        {
            CreateMap<RegisterDTO, AddUserModel>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Nickname, opt => opt.MapFrom(src => src.Nickname??src.Username))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}
