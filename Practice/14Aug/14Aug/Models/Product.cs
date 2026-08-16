namespace _14Aug.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ICollection<CustomerProduct> CustomerProducts { get; set; } = new List<CustomerProduct>();
    }
}
