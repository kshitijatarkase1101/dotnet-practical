using System.ComponentModel.DataAnnotations;

namespace _12Aug.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Bookings is mandatory")]
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
