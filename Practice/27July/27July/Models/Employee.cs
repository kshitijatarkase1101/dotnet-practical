using System.ComponentModel.DataAnnotations;

namespace _27July.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Emp id is required")]
        public int id { get; set; }
        [Required(ErrorMessage = "Emp Name is required")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Name must be atleast 3 letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Emp LastName is required")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Emp Dept is required")]
        [StringLength(25, ErrorMessage = "Dept cannot be more than 25 letters")]
        public string Dept { get; set; }
        [Required(ErrorMessage = "Emp PhoneNum is required")]
        public long PhoneNum { get; set; }

        [Required(ErrorMessage = " Emp Profile is required")]
        public String Profile { get; set; }
        [Required(ErrorMessage = " Emp location is required")]
        public string Location { get; set; }
    }
}
