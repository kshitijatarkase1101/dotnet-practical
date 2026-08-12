using System.ComponentModel.DataAnnotations;

namespace _10AugAssignment.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone no.  is required")]
        [Phone(ErrorMessage ="Enter valid phone no.")]
        public int Phone {  get; set; }
        [Required(ErrorMessage = "Email of customer is required")]
        [EmailAddress(ErrorMessage ="Enter valid email")]
        public string email {  get; set; }
    }
}
