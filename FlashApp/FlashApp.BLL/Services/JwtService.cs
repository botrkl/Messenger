using FlashApp.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FlashApp.BLL.Services
{
    public class JwtService : IJwtService
    {
        public string CreateJWT(Guid userId, IConfiguration configuration)
        {
            var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            };
            var token = new JwtSecurityToken(issuer: configuration["JwtSettings:Issuer"], audience: configuration["JwtSettings:Audience"], claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public Guid GetId(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            string userId = jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value;
            return Guid.Parse(userId);
        }
    }
}
