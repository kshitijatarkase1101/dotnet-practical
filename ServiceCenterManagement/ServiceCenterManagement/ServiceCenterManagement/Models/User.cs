using System.ComponentModel.DataAnnotations;

namespace ServiceCenterManagement.Models
{
    public class User
    {
        
            // Primary Key
            public int UserId { get; set; }

            [Required(ErrorMessage = "Username is required")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Role is required")]
            public string Role { get; set; }
        
    }
}

