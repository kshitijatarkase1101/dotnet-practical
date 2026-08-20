using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
       
            private readonly IInvoiceService service;

            public InvoiceController(IInvoiceService service)
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
                Invoice invoice = service.GetById(id);

                if (invoice == null)
                {
                    return NotFound("Invoice not found");
                }

                return Ok(invoice);
            }

            [HttpPost]
            public IActionResult Add(Invoice invoice)
            {
                service.Add(invoice);

                return Ok("Invoice added successfully");
            }

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

