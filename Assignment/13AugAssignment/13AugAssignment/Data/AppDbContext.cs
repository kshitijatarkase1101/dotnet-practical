using _13AugAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace _13AugAssignment.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products12 { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "admin",
                    Password = "1234",
                    Role = "Admin"
                },
                new Customer
                {
                    Id = 2,
                    Name = "customer",
                    Password = "1234",
                    Role = "Customer"
                }
                );
        }
    }
}
