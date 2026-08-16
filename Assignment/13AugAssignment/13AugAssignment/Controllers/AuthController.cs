using _13AugAssignment.Models;
using _13AugAssignment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _13AugAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }

        [HttpPost("register")]
        public IActionResult Register(Customer customer)
        {
            try
            {
                var result = service.Register(customer);

                return Ok(new
                {
                    message = "Registration successful",
                    customer = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        // LOGIN
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            var token = service.Login(username, password);

            if (token == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid username or password"
                });
            }

            return Ok(new
            {
                message = "Login successful",
                token = token
            });
        }
    }
}
