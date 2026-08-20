using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ServiceCenterManagement.Models
{
    public class ServicePart
    {

        //Primary key
        public int ServicePartId { get; set; }
        //Foreign Key
        public int ServiceRequestId { get; set; }
        public int PartId { get; set; }
        [Required(ErrorMessage = "Quantity used is required")]
        public int QuantityUsed { get; set; }
        [Required(ErrorMessage = "Service Part price is required")]
        public decimal Price { get; set; }

        //navigation property
        [JsonIgnore]
        public ServiceRequest? ServiceRequest { get; set; }
        [JsonIgnore]
        public Part? Part { get; set; }

    }
}
