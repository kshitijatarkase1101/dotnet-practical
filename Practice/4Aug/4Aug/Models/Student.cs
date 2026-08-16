using System.ComponentModel.DataAnnotations;

namespace _4Aug.Models
{
    public class Student
    {
        [Required(ErrorMessage ="ID is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50,ErrorMessage ="Name must not excced 50 letters",MinimumLength=3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age  is required")]
        public int Age {  get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email{ get; set; }

    }
}
