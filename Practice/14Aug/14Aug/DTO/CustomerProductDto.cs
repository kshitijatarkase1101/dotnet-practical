using _14Aug.Models;
using System.ComponentModel.DataAnnotations;

namespace _14Aug.DTO
{
    public class CustomerProductDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Range(1,100)]
        public int Quantity { get; set; }
    }
}
