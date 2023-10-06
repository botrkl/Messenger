using Microsoft.Extensions.Configuration;

namespace FlashApp.BLL.Services.Interfaces
{
    public interface IJwtService
    {
        public string CreateJWT(Guid userId, IConfiguration configuration);
        public Guid GetId(string token);
    }
}
