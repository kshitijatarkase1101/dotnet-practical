using System.ComponentModel.DataAnnotations;

namespace _12Aug.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="UserName is requird")]
        [StringLength(10,ErrorMessage ="10 Max letter can be strored  ")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is requird")]
        [StringLength(16, ErrorMessage = "16 Max letter can be strored ")]
        public string Password { get; set; }=string.Empty;
        [Required(ErrorMessage = "Role is requird")]
        [StringLength(20, ErrorMessage = "20 Max letter can be strored")] 
        public string Role {  get; set; } = string.Empty;
    }
}
