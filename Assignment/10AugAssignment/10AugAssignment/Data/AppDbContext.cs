using _10AugAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace _10AugAssignment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Customer> Customer => Set<Customer>();
        public DbSet<Automobile> Automobiles => Set<Automobile>();
        public DbSet<Company> Companies=> Set<Company>();
        public DbSet<Purchase> Purchases => Set<Purchase>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>().HasOne(b => b.Customer).WithMany().HasForeignKey(b => b.AutomobileId);
            modelBuilder.Entity<Purchase>().HasOne(b => b.Customer).WithMany().HasForeignKey(b => b.ComapanyId);
            modelBuilder.Entity<Purchase>().HasOne(b => b.Customer).WithMany().HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Purchase>().HasIndex(b => new { b.AutomobileId, b.ComapanyId, b.CustomerId }).IsUnique();
        }
    }

}
