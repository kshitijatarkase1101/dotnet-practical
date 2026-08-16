using _7Aug.Models;

namespace _7Aug.Repository
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        Product AddProduct(Product product);
    }
}
