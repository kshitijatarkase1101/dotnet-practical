using _7Aug.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _7Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService service; 
        public OrderController(IOrderService service)
        { 
            this.service = service; 
        } 
        [HttpGet]
        public ActionResult Get() 
        { 
            return Ok(service.GetOrders());
        } 

    }
}
