using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ServiceCenterManagement.Models
{
    public class ServiceRequest
    {

        //Primary Key
        public int ServiceRequestId {  get; set; }

        //foreign keys
        public int VehicleId {  get; set; }
        public int CustomerId {  get; set; }
        public int TechnicianId {  get; set; }
        
        [Required(ErrorMessage ="Request Date is required")]
         public DateOnly RequestDate {  get; set; }
        [Required(ErrorMessage = "Problem Description Date is required")]
        public string ProblemDescription {  get; set; }
        [Required(ErrorMessage = "Service Type Date is required")]
        public string ServiceType {  get; set; }
        [Required(ErrorMessage = "Status Date is required")]
        public string Status {  get; set; }
        [Required(ErrorMessage = "Priority Date is required")]
        public string Priority {  get; set; }

        // Navigation Properties
        [JsonIgnore]
        public Vehicle? Vehicle { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }
        [JsonIgnore]
        public Technician? Technician { get; set; }
        [JsonIgnore]
        public Invoice? Invoice {  get; set; }
       
        [JsonIgnore]
        public ICollection<ServicePart> ServiceParts { get; set; } = new List<ServicePart>();
    }
}
