using AutoMapper;
using FlashApp.BLL.Models;
using FlashApp.DAL.Entities;

namespace FlashApp.BLL.Mapping
{
    public class ChatMapperProfile:Profile
    {
        public ChatMapperProfile()
        {
            CreateMap<Chat, ChatModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.users, opt => opt.MapFrom(src => src.ChatUsers.Select(chatUser => chatUser.User)))
            .ForMember(dest => dest.messages, opt => opt.MapFrom(src => src.Messages));
        }
    }
}
