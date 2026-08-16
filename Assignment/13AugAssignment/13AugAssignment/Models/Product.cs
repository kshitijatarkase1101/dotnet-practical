using System.ComponentModel.DataAnnotations;

namespace _13AugAssignment.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }=string.Empty;
        [Required(ErrorMessage = "Description is required")]
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Price is required")]
        [Range(0, 100000)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Stock is required")]
        public int Stock {  get; set; }
    }
}
