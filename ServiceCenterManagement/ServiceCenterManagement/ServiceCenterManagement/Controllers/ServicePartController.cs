using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(ServicePart servicePart)
        {
            service.Add(servicePart);

            return Ok("Service part added successfully");
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

