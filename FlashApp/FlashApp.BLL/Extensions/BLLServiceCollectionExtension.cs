using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FlashApp.BLL.Services;
using FlashApp.BLL.Services.Interfaces;
using FlashApp.BLL.Mapping;

namespace FlashApp.BLL.Extensions
{
    public static class BLLServiceCollectionExtension
    {
        public static void InjectBLLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddAutoMapper(typeof(ChatMapperProfile));
            services.AddAutoMapper(typeof(MessageMapperProfile));
            services.AddAutoMapper(typeof(UserMapperProfile));
        }
    }
}
