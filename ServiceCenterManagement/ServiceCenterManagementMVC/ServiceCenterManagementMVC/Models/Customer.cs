using System.ComponentModel.DataAnnotations;

namespace ServiceCenterManagementMVC.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is mandatory")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone no. of Customer is mandatory")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Customer address is mandatory")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }
    }
}
