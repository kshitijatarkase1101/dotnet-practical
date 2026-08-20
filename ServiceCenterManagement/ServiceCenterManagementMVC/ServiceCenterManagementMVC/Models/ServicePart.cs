using System.ComponentModel.DataAnnotations;

namespace ServiceCenterManagementMVC.Models
{
    public class ServicePart
    {
       
            public int ServicePartId { get; set; }

            public int ServiceRequestId { get; set; }

            public int PartId { get; set; }

            [Required(ErrorMessage = "Quantity used is required")]
            public int QuantityUsed { get; set; }

            [Required(ErrorMessage = "Service Part price is required")]
            public decimal Price { get; set; }
        
    }
}

