using _7Aug.Models;
using Microsoft.EntityFrameworkCore;

namespace _7Aug.Data
{
    public class AppDbContext : DbContext
    {

        //constructor receives db configuration through DI
        public AppDbContext(DbContextOptions options) : base(options) { }
        //represents the products table in db
        public DbSet<Product> Products => Set<Product>();
        //represents the Orders table in db
        public DbSet<Orders> Orders => Set<Orders>();
        //confugure relationships between entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { //one product -> many orderitems
            modelBuilder.Entity<OrderItems>().HasOne(o => o.product).WithMany(p => p.OrderItems).HasForeignKey(o => o.ProductId);
            //one order -> many orderitems
            modelBuilder.Entity<OrderItems>().HasOne(o => o.Order).WithMany(p => p.OrderItems).HasForeignKey(o => o.OrderId);
        }
    }
}
