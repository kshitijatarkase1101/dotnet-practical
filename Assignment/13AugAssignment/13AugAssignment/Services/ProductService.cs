using _13AugAssignment.Data;
using _13AugAssignment.Models;
using _13AugAssignment.Repository;
using Microsoft.EntityFrameworkCore;

namespace _13AugAssignment.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;

        public ProductService(AppDbContext context)
        {
            this.context = context;
        }

        public Product AddProducts(Product products)
        {
            context.Products12.Add(products);
            context.SaveChanges();
            return products;
        }

        public Product? DeleteProduct(int id)
        {
            var product = context.Products12
              .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            context.Products12.Remove(product);
            context.SaveChanges();

            return product;
        }

        public Product? GetProductById(int id)
        {
            return context.Products12.Find(id);
        }

        public List<Product> GetProducts()
        {
            return context.Products12.ToList();
        }

        public Product? UpdateProducts(Product products)
        {
            var existingProduct = context.Products12
                .FirstOrDefault(p => p.Id == products.Id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = products.Name;
            existingProduct.Description = products.Description;
            existingProduct.Price = products.Price;
            existingProduct.Stock = products.Stock;

            context.SaveChanges();

            return existingProduct;
        }
    }
}
