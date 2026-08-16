namespace _14Aug.Models
{
    public class CustomerProduct
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null;
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }





    }
}
