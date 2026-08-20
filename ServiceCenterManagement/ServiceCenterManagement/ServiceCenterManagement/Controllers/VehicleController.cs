using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
       
            private readonly IVehicleService service;

            public VehicleController(IVehicleService service)
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
                Vehicle vehicle = service.GetById(id);

                if (vehicle == null)
                {
                    return NotFound("Vehicle not found");
                }

                return Ok(vehicle);
            }

            [HttpPost]
            public IActionResult Add(Vehicle vehicle)
            {
                service.Add(vehicle);

                return Ok("Vehicle added successfully");
            }

            [HttpPut]
            public IActionResult Update(Vehicle vehicle)
            {
                Vehicle existingVehicle = service.GetById(vehicle.VehicleId);

                if (existingVehicle == null)
                {
                    return NotFound("Vehicle not found");
                }

                service.Update(vehicle);

                return Ok("Vehicle updated successfully");
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                Vehicle vehicle = service.GetById(id);

                if (vehicle == null)
                {
                    return NotFound("Vehicle not found");
                }

                service.Delete(id);

                return Ok("Vehicle deleted successfully");
            }
        
    }
}

