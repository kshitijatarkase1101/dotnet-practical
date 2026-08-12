using _5AugAssignment.Models;
using _5AugAssignment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _5AugAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository service;

        public OrderController(IOrderRepository service)
        {
            this.service = service;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = service.GetOrder(id);
            if (order == null)
                return NotFound("Order is not available");
            return Ok(order);
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            service.AddOrder(order);
            return Ok(order);
        }

        [HttpPut]
        public IActionResult UpdateOrder(Order order)
        {
            service.UpdateOrder(order);
            return Ok("Order updated successfully");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            service.DeleteOrder(id);
            return Ok("Order Deleted successfully");
        }

    }
}
