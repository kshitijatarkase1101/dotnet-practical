using System.ComponentModel.DataAnnotations;

namespace _13AugAssignment.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Customer Name is mnadatory")]
        public string Name { get; set; }=string.Empty;
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Enter correct email")]
        public string Email {  get; set; }= string.Empty;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = string.Empty;
    }
}
