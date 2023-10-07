using FlashApp.DAL.Context;
using FlashApp.DAL.Repositories.Interfaces;
using FlashApp.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FlashApp.DAL.Extensions
{
    public static class DALServiceCollectionExtension
    {
        public static void InjectDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MessengerDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"]);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatUserRepository, ChatUserRepository>();
        }
    }
}
