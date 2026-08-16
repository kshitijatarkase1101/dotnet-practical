using _14Aug.Data;
using _14Aug.Models;
using _14Aug.Repository;

namespace _14Aug.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;

        public ProductService (AppDbContext context)
        {
            this .context = context;
        }
        public Product AddProduct(Product product)
        {
            context.Products.Add(product);
                context.SaveChanges();
            return product;
        }

        

        public Product GetProductById(int id)
        {
            return context.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            context.Products.Update(product);
                context.SaveChanges();
            return product;
        }
    }
}
