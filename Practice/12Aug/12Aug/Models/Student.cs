using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace _12Aug.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(30,ErrorMessage ="30 Max letters are allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Age is required")]
        [Range(18,25,ErrorMessage ="Age must be between 18 and 25")]
        public int Age { get; set; }

        [Required(ErrorMessage="Mail id is required")]
        [StringLength(30,ErrorMessage ="30 Max letters are allowed")]
        [EmailAddress(ErrorMessage ="Phone number is incorrect")]
        public string Mail {  get; set; }
        [Required(ErrorMessage ="Phone number is required")]
        [Phone(ErrorMessage ="Phone number is incorrect")]
        public int PhoneNumber{  get; set; }
        [Required(ErrorMessage = "Course Name is required")]
        [StringLength(30, ErrorMessage = "30 Max letters are allowed")]
        public string Course {  get; set; }=string.Empty;

    }
}
