using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
       
            private readonly ITechnicianService service;

            public TechnicianController(ITechnicianService service)
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
                Technician technician = service.GetById(id);

                if (technician == null)
                {
                    return NotFound("Technician not found");
                }

                return Ok(technician);
            }

            [HttpPost]
            public IActionResult Add(Technician technician)
            {
                service.Add(technician);

                return Ok("Technician added successfully");
            }

            [HttpPut]
            public IActionResult Update(Technician technician)
            {
                Technician existingTechnician =
                    service.GetById(technician.TechnicianId);

                if (existingTechnician == null)
                {
                    return NotFound("Technician not found");
                }

                service.Update(technician);

                return Ok("Technician updated successfully");
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                Technician technician = service.GetById(id);

                if (technician == null)
                {
                    return NotFound("Technician not found");
                }

                service.Delete(id);

                return Ok("Technician deleted successfully");
            }
        
    }
}

