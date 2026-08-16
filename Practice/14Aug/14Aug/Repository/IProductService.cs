using _14Aug.Models;

namespace _14Aug.Repository
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        Product AddProduct(Product product) ;
        Product UpdateProduct(Product product) ;
        
    }
}
