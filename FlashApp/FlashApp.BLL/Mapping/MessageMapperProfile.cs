using AutoMapper;
using FlashApp.BLL.Models;
using FlashApp.BLL.Models.AddModels;
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
                .ForMember(dest => dest.User_id, opt => opt.MapFrom(src => src.User_id.ToString()))
                .ForMember(dest => dest.Chat_id, opt => opt.MapFrom(src => src.Chat_id.ToString()));

            CreateMap<AddMessageModel, Message>()
                .ForMember(message => message.User_id, opt => opt.MapFrom(messageModel => Guid.Parse(messageModel.User_id)))
                .ForMember(message => message.Chat_id, opt => opt.MapFrom(messageModel => Guid.Parse(messageModel.Chat_id)))
                .ForMember(message => message.Creation_Time, opt => opt.MapFrom(messageModel => messageModel.Creation_Time));
        }
    }
}
