using Microsoft.EntityFrameworkCore;
using ServiceCenterManagement.Models;

namespace ServiceCenterManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }

        public DbSet<Technician> Technicians { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<ServicePart> ServiceParts { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customer → Vehicle
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Customer)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Customer → ServiceRequest
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.Customer)
                .WithMany()
                .HasForeignKey(sr => sr.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Vehicle → ServiceRequest
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.Vehicle)
                .WithMany(v => v.ServiceRequests)
                .HasForeignKey(sr => sr.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
            // Technician → ServiceRequest
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.Technician)
                .WithMany(t => t.ServiceRequests)
                .HasForeignKey(sr => sr.TechnicianId)
                .OnDelete(DeleteBehavior.Restrict);

            // ServiceRequest → ServicePart
            modelBuilder.Entity<ServicePart>()
                .HasOne(sp => sp.ServiceRequest)
                .WithMany(sr => sr.ServiceParts)
                .HasForeignKey(sp => sp.ServiceRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Part → ServicePart
            modelBuilder.Entity<ServicePart>()
                .HasOne(sp => sp.Part)
                .WithMany(p => p.ServiceParts)
                .HasForeignKey(sp => sp.PartId)
                .OnDelete(DeleteBehavior.Restrict);

            // ServiceRequest → Invoice
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.ServiceRequest)
                .WithOne(sr => sr.Invoice)
                .HasForeignKey<Invoice>(i => i.ServiceRequestId)
                .OnDelete(DeleteBehavior.Cascade);
            // Invoice → Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Invoice)
                .WithOne(i => i.Payment)
                .HasForeignKey<Payment>(p => p.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        }
    }
