using _12Aug.Data;
using _12Aug.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _12Aug.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext context;
        private readonly IConfiguration configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public string? Login(string username , string password)
        {
            var user = context.Users12.FirstOrDefault(u => u.UserName == username && u.Password == password );    

            if (user == null)
                return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

            var credentials= new SigningCredentials(key, SecurityAlgorithms.HmacSha256) ;


            var token = new JwtSecurityToken(issuer: configuration["Jwt:Issuer"], audience: configuration["Jwt:Audience"], claims: claims,
                expires:DateTime.UtcNow.AddHours(1),signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
