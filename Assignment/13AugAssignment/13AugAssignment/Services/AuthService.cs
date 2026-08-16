using _13AugAssignment.Data;
using _13AugAssignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _13AugAssignment.Repository
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<Customer> _passwordHasher;

        public AuthService(
            AppDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _passwordHasher = new PasswordHasher<Customer>();
        }

        // REGISTER
        public Customer Register(Customer customer)
        {
            // Check whether email already exists
            var existingCustomer = _context.Customer
                .FirstOrDefault(c => c.Email == customer.Email);

            if (existingCustomer != null)
            {
                throw new Exception("Email already registered");
            }

            // Default role = Customer
            customer.Role = "Customer";

            // Hash password
            customer.Password = _passwordHasher.HashPassword(
                customer,
                customer.Password
            );

            _context.Customer.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        // LOGIN
        public string? Login(string email, string password)
        {
            var customer = _context.Customer
                .FirstOrDefault(c => c.Email == email);

            if (customer == null)
            {
                return null;
            }

            // Verify password
            var result = _passwordHasher.VerifyHashedPassword(
                customer,
                customer.Password,
                password
            );

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            // Create JWT
            return GenerateToken(customer);
        }

        // GENERATE JWT TOKEN
        private string GenerateToken(Customer customer)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,
                    customer.Id.ToString()),

                new Claim(ClaimTypes.Name,
                    customer.Name),

                new Claim(ClaimTypes.Email,
                    customer.Email),

                new Claim(ClaimTypes.Role,
                    customer.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!
                )
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}