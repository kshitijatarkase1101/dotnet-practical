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

            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(service.GetAll());
            }

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

            [HttpPost]
            public IActionResult Add(Payment payment)
            {
                service.Add(payment);

                return Ok("Payment added successfully");
            }

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

