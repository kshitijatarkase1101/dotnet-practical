using System.ComponentModel.DataAnnotations;

namespace _10AugAssignment.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ComapanyId {  get; set; }
        public int AutomobileId {  get; set; }
        public int CustomerId {  get; set; }
        [Required(ErrorMessage ="Price of automobile is required")]
        public int price {  get; set; }
        [Required(ErrorMessage = "Price of automobile is required")]
        public DateTime PurchaseDate {  get; set; }
        public Automobile? Automobile { get; set; }
        public Company? Company { get; set; }
        public Customer? Customer { get; set; }
    }
}
