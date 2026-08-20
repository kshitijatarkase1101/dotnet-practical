using System.ComponentModel.DataAnnotations;

namespace ServiceCenterManagement.Models
{
    public class Vehicle
    { 
        //Primary Key
        public int VehicleId { get; set; }
        //foreign key
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Vehicle number is  mandatory")]
        public string VehicleNumber {  get; set; }
        [Required(ErrorMessage = "Vehicle brand is  mandatory")]
        public string Brand {  get; set; }
        [Required(ErrorMessage = "Model is  mandatory")]
        public string Model {  get; set; }
        [Required(ErrorMessage = "Year  is  mandatory")]
        public int Year {  get; set; }
        [Required(ErrorMessage = "Vehicle type is  mandatory")]
        public string VehicleType {  get; set; }

        //navigation property
        public Customer Customer { get; set; }
        public ICollection<ServiceRequest> ServiceRequests {  get; set; }


    }
}
