using _5Aug.Models;
using Microsoft.EntityFrameworkCore;

namespace _5Aug.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options)  : base(options) { }
        public DbSet<Product> Products {  get; set; }
    }
}
