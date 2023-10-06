using AutoMapper;
using FlashApp.BLL.Models;
using FlashApp.DAL.Entities;

namespace FlashApp.BLL.Mapping
{
    public class MessageMapperProfile:Profile
    {
        public MessageMapperProfile()
        {
            CreateMap<Message, MessageModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Creation_Time, opt => opt.MapFrom(src => src.Creation_Time.ToString()))
                .ForMember(dest => dest.User_id, opt => opt.MapFrom(src => src.User.Id.ToString()))
                .ForMember(dest => dest.Chat_id, opt => opt.MapFrom(src => src.Chat.Id.ToString()));
        }
    }
}
