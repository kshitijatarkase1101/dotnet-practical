using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            [HttpPost]
            public IActionResult Add(ServiceRequest serviceRequest)
            {
                service.Add(serviceRequest);

                return Ok("Service request added successfully");
            }

            [HttpPut]
            public IActionResult Update(ServiceRequest serviceRequest)
            {
                ServiceRequest existingRequest =
                    service.GetById(serviceRequest.ServiceRequestId);

                if (existingRequest == null)
                {
                    return NotFound("Service request not found");
                }

                service.Update(serviceRequest);

                return Ok("Service request updated successfully");
            }

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

