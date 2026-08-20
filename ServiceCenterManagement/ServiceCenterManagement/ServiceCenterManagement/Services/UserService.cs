using Microsoft.IdentityModel.Tokens;
using ServiceCenterManagement.Data;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceCenterManagement.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext context;
        private readonly IConfiguration configuration;

        public UserService(
            AppDbContext context,
            IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public void Register(User user)
        {
            User existingUser = context.Users
                .FirstOrDefault(u => u.Username == user.Username);

            if (existingUser != null)
            {
                throw new Exception("Username already exists");
            }

            context.Users.Add(user);
            context.SaveChanges();
        }

        public string Login(string username, string password)
        {
            User user = context.Users.FirstOrDefault(u =>
                u.Username == username &&
                u.Password == password);

            if (user == null)
            {
                throw new Exception("Invalid username or password");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}