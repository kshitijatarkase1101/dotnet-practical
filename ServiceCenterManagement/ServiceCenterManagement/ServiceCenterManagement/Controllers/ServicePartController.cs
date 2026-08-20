using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePartController : ControllerBase
    {
      
            private readonly IServicePartService service;

            public ServicePartController(IServicePartService service)
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
                ServicePart servicePart = service.GetById(id);

                if (servicePart == null)
                {
                    return NotFound("Service part not found");
                }

                return Ok(servicePart);
            }

            [HttpPost]
            public IActionResult Add(ServicePart servicePart)
            {
                service.Add(servicePart);

                return Ok("Service part added successfully");
            }

            [HttpPut]
            public IActionResult Update(ServicePart servicePart)
            {
                ServicePart existingServicePart =
                    service.GetById(servicePart.ServicePartId);

                if (existingServicePart == null)
                {
                    return NotFound("Service part not found");
                }

                service.Update(servicePart);

                return Ok("Service part updated successfully");
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                ServicePart servicePart = service.GetById(id);

                if (servicePart == null)
                {
                    return NotFound("Service part not found");
                }

                service.Delete(id);

                return Ok("Service part deleted successfully");
            }
        
    }
}

