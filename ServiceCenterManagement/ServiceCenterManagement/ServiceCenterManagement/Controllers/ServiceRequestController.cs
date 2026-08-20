using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestService service;

        public ServiceRequestController(IServiceRequestService service)
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
            ServiceRequest request = service.GetById(id);

            if (request == null)
            {
                return NotFound("Service request not found");
            }

            return Ok(request);
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpPost]
        public IActionResult Add(ServiceRequest serviceRequest)
        {
            service.Add(serviceRequest);

            return Ok("Service request added successfully");
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Technician")]
        public IActionResult Update(ServiceRequest serviceRequest)
        {
            try
            {
                service.Update(serviceRequest);

                return Ok("Service request updated successfully");
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
            ServiceRequest serviceRequest = service.GetById(id);

            if (serviceRequest == null)
            {
                return NotFound("Service request not found");
            }

            service.Delete(id);

            return Ok("Service request deleted successfully");
        }
    }
}