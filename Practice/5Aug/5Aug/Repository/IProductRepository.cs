using _5Aug.Models;

namespace _5Aug.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);

    }
}
