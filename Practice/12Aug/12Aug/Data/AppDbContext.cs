using _12Aug.Models;
using Microsoft.EntityFrameworkCore;

namespace _12Aug.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> Students12 { get; set; }
        public DbSet<User> Users12 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    Password = "1234",
                    Role = "Admin"
                },
                new User
                {
                    Id= 2,
                    UserName="student",
                    Password="1234",
                    Role="Student"
                }
                );
        }
    }
}
