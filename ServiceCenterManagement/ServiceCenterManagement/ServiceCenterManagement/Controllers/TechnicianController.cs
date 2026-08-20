using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TechnicianController : ControllerBase
    {
        private readonly ITechnicianService service;

        public TechnicianController(ITechnicianService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Admin,Technician")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [Authorize(Roles = "Admin,Technician")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Technician technician)
        {
            service.Add(technician);

            return Ok("Technician added successfully");
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Technician technician)
        {
            try
            {
                service.Update(technician);

                return Ok("Technician updated successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
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