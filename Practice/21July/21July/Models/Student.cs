using System.ComponentModel.DataAnnotations;

namespace _21July.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Student name is mandatory")]
        [StringLength(20,MinimumLength =3,ErrorMessage ="Student name must be atleast 3 letters and max 20 letters")]
       public  string Name {  get; set; }
       
        [Required(ErrorMessage ="Student age is mandatory")]
        [Range(18,25,ErrorMessage ="Student age must be between 18 and 25")]
       public  int age { get; set; }
       
        [Required(ErrorMessage ="Student email is mandatory")]
        [EmailAddress(ErrorMessage ="Email is incorrect, Enter a valid email ID")]
       public  string email {  get; set; }
        
        [Required(ErrorMessage ="Student enrolled course is mandatory ")]
       public  string course {  get; set; }
    }
}
