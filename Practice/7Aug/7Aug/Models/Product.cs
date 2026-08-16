using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace _7Aug.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is mandatory")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock{ get; set; }
        public ICollection<OrderItems>? OrderItems { get; set; }
    }

}
