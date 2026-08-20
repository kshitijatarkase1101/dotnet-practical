using System.ComponentModel.DataAnnotations;

namespace ServiceCenterManagementMVC.Models
{
    public class Vehicle
    {
        
            public int VehicleId { get; set; }

            public int CustomerId { get; set; }

            [Required(ErrorMessage = "Vehicle number is mandatory")]
            public string VehicleNumber { get; set; }

            [Required(ErrorMessage = "Vehicle brand is mandatory")]
            public string Brand { get; set; }

            [Required(ErrorMessage = "Model is mandatory")]
            public string Model { get; set; }

            [Required(ErrorMessage = "Year is mandatory")]
            public int Year { get; set; }

            [Required(ErrorMessage = "Vehicle type is mandatory")]
            public string VehicleType { get; set; }
        
    }
}

