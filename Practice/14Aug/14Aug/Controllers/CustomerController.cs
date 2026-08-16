using _14Aug.Models;
using _14Aug.Repository;
using _14Aug.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _14Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
             service.GetCustomers();

            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetCustomer(int id)
        {
          var customer=  service.GetCustomerById(id);
            if (customer == null)
                return NotFound("Not Found");
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddCustomer(Customer customer)
        {
            service.Add(customer);
            return Ok();
        }
     }
}
