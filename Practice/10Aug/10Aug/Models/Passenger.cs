using System.ComponentModel.DataAnnotations;

namespace _10Aug.Models
{
    public class Passenger
    {
        public int Id {  get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name {  get; set; }
        [Required(ErrorMessage ="Phone number is required")]
        [Phone(ErrorMessage ="Phone is not correct")]
        public int Phone {  get; set; } 
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Email address is not correct")]
        public string Email {  get; set; }
    }
}
