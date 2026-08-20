using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
       
            private readonly IPartService service;

            public PartController(IPartService service)
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
                Part part = service.GetById(id);

                if (part == null)
                {
                    return NotFound("Part not found");
                }

                return Ok(part);
            }

            [HttpPost]
            public IActionResult Add(Part part)
            {
                service.Add(part);

                return Ok("Part added successfully");
            }

            [HttpPut]
            public IActionResult Update(Part part)
            {
                Part existingPart = service.GetById(part.PartId);

                if (existingPart == null)
                {
                    return NotFound("Part not found");
                }

                service.Update(part);

                return Ok("Part updated successfully");
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                Part part = service.GetById(id);

                if (part == null)
                {
                    return NotFound("Part not found");
                }

                service.Delete(id);

                return Ok("Part deleted successfully");
            }
        
    }
}

