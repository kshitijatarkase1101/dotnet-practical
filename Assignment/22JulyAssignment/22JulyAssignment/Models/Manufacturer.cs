using System.ComponentModel.DataAnnotations;

namespace _22JulyAssignment.Models
{
    public class Manufacturer
    {
        [Required(ErrorMessage ="Name is mandatory")]      
            public string Name { get; set; }
        [Required(ErrorMessage = "Name is mandatory")] public string Country {  get; set; }
        [Required(ErrorMessage = "Name is mandatory")] 
        public long ContactNumber {  get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        [EmailAddress(ErrorMessage ="Enter valid mail Id")]
        public string Email {  get; set; }
    }
}
