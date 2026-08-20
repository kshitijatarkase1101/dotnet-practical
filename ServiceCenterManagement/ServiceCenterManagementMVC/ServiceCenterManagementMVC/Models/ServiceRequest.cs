using System.ComponentModel.DataAnnotations;

namespace ServiceCenterManagementMVC.Models
{
    public class ServiceRequest
    {
       
        
            public int ServiceRequestId { get; set; }

            public int VehicleId { get; set; }

            public int CustomerId { get; set; }

            public int TechnicianId { get; set; }

            [Required(ErrorMessage = "Request Date is required")]
            public DateOnly RequestDate { get; set; }

            [Required(ErrorMessage = "Problem Description is required")]
            public string ProblemDescription { get; set; }

            [Required(ErrorMessage = "Service Type is required")]
            public string ServiceType { get; set; }

            [Required(ErrorMessage = "Status is required")]
            public string Status { get; set; }

            [Required(ErrorMessage = "Priority is required")]
            public string Priority { get; set; }
        }
    
}

