using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
       
            private readonly ICustomerService service;

            public CustomerController(ICustomerService service)
            {
                this.service = service;
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(service.GetAll());
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                Customer customer = service.GetById(id);

                if (customer == null)
                {
                    return NotFound("Customer not found");
                }

                return Ok(customer);
            }

            [HttpPost]
            public IActionResult Add(Customer customer)
            {
                service.Add(customer);

                return Ok("Customer added successfully");
            }

            [HttpPut]
            public IActionResult Update(Customer customer)
            {
                Customer existingCustomer = service.GetById(customer.CustomerId);

                if (existingCustomer == null)
                {
                    return NotFound("Customer not found");
                }

                service.Update(customer);

                return Ok("Customer updated successfully");
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                Customer customer = service.GetById(id);

                if (customer == null)
                {
                    return NotFound("Customer not found");
                }

                service.Delete(id);

                return Ok("Customer deleted successfully");
            }
        
    }
}

