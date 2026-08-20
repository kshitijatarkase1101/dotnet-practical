using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService service;

        public InvoiceController(IInvoiceService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Admin,Customer,Technician")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [Authorize(Roles = "Admin,Customer,Technician")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Invoice invoice = service.GetById(id);

            if (invoice == null)
            {
                return NotFound("Invoice not found");
            }

            return Ok(invoice);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Invoice invoice)
        {
            service.Add(invoice);

            return Ok("Invoice added successfully");
        }
       
        
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update(Invoice invoice)
        {
            Invoice existingInvoice = service.GetById(invoice.InvoiceId);

            if (existingInvoice == null)
            {
                return NotFound("Invoice not found");
            }

            service.Update(invoice);

            return Ok("Invoice updated successfully");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Invoice invoice = service.GetById(id);

            if (invoice == null)
            {
                return NotFound("Invoice not found");
            }

            service.Delete(id);

            return Ok("Invoice deleted successfully");
        }
    }
}

