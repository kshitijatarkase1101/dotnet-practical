using System.ComponentModel.DataAnnotations;

namespace _7Aug.Models
{
    public class Orders
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="CustomerName is required")]
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }= DateTime.Now;
        public ICollection<OrderItems>OrderItems { get; set; }


    }
}
