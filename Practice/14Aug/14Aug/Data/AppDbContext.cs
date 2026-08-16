using _14Aug.Models;
using Microsoft.EntityFrameworkCore;

namespace _14Aug.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<CustomerProduct> CustomerProducts => Set<CustomerProduct>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomerProduct>().HasKey(cp => new { cp.CustomerId, cp.ProductId});
            // customer -> customerproduct
            modelBuilder.Entity<CustomerProduct>().HasOne(cp => cp.Customer).WithMany(c => c.CustomerProducts).HasForeignKey(cp => cp.CustomerId).OnDelete(DeleteBehavior.Cascade);

            //product -> customerproduct
            modelBuilder.Entity<CustomerProduct>().HasOne(cp => cp.Product).WithMany(c => c.CustomerProducts).HasForeignKey(cp => cp.ProductId).OnDelete(DeleteBehavior.Cascade);

            // email must be unique
            modelBuilder.Entity<Customer>().HasIndex( c=> c.Email).IsUnique();
        }


    }
}
