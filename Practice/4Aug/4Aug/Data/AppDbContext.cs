using _4Aug.Models;
using Microsoft.EntityFrameworkCore;
using _4AugAssignment.Models;

namespace _4Aug.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Batch> Batches {  get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
