
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService service;

        public AuthController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            service.Register(user);

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            string token = service.Login(username, password);

            return Ok(new
            {
                message = "Login successful",
                token = token
            });
        }
    }
}