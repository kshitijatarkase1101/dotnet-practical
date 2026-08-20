using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService service;

        public PaymentController(IPaymentService service)
        {
            this.service = service;
        }

        
        [Authorize(Roles = "Admin,Technician")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        
        [Authorize(Roles = "Admin,Customer,Technician")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Payment payment = service.GetById(id);

            if (payment == null)
            {
                return NotFound("Payment not found");
            }

            return Ok(payment);
        }

        
        [Authorize(Roles = "Admin,Customer")]
        [HttpPost]
        public IActionResult Add(Payment payment)
        {
            service.Add(payment);

            return Ok("Payment added successfully");
        }

        
        [Authorize(Roles = "Admin,Customer")]
        [HttpPut]
        public IActionResult Update(Payment payment)
        {
            Payment existingPayment = service.GetById(payment.PaymentId);

            if (existingPayment == null)
            {
                return NotFound("Payment not found");
            }

            service.Update(payment);

            return Ok("Payment updated successfully");
        }

        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Payment payment = service.GetById(id);

            if (payment == null)
            {
                return NotFound("Payment not found");
            }

            service.Delete(id);

            return Ok("Payment deleted successfully");
        }
    }
}

