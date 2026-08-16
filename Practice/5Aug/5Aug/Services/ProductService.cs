using _5Aug.Data;
using _5Aug.Models;
using _5Aug.Repository;

namespace _5Aug.Services
{
    public class ProductService : IProductRepository
    {
        
        private readonly AppDbContext context;
        public ProductService(AppDbContext context)
        {
            this.context = context;
        }



        public void AddProduct(Product product)
        {
             context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = context.Products.Find(id);
                if(product != null) 
                context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<Product> GetAll()
        {
           return  context.Products.ToList();
        }

        public Product? GetProduct(int id)
        {
            return context.Products.Find(id);

        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();

        }
    }
}
