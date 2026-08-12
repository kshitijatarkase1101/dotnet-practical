
using _5AugAssignment.Repository;

    using _5AugAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace _5AugAssignment.Data


{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Order> Orders{ get; set; }

    }
}
