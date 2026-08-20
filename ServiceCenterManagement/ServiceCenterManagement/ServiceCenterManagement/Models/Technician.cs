using System.ComponentModel.DataAnnotations;

namespace ServiceCenterManagement.Models
{
    public class Technician
    {
        //Primary Key
        public int TechnicianId {  get; set; }
       
        [Required(ErrorMessage ="Name is required")]
        [StringLength(20)]
        public string Name {  get; set; }
        [Required(ErrorMessage = "Phone no.  is required")]
        public string Phone {  get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Specialization is required")]
        public string Specialization {  get; set; }
        [Required(ErrorMessage = "Experience  is required")]
        public string Experience {  get; set; }
        [Required(ErrorMessage = "Avaliability is required")]
        public string Availability {  get; set; }

        
        public ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
