using _7Aug.Models;
using _7Aug.Repository;
using _7Aug.Data;
using Microsoft.EntityFrameworkCore;

namespace _7Aug.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;


        public ProductService(AppDbContext context)
        {
            this.context = context;
        }

        public Product AddProduct(Product product)
        {
            context.Products.Add(product); 
            context.SaveChanges(); 
            return product;
        }

        public Product? GetProductById(int id)
        {
            return context.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }
    }
}
