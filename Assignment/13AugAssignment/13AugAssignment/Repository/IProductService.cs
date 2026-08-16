using _13AugAssignment.Models;

namespace _13AugAssignment.Repository
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        Product AddProducts(Product products);
        Product? UpdateProducts(Product products);
        Product? DeleteProduct(int id);

    }
}
