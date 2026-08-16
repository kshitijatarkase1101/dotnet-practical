using _12Aug.Models;
using Microsoft.EntityFrameworkCore;

namespace _12Aug.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customer {  get; set; }
        public DbSet<Hotel> Hotels {  get; set; }
        public DbSet<Room> Rooms {  get; set; }
        public DbSet<BookingRoom> BookingRooms {  get; set; }
        public DbSet<Booking> Bookings {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(br => br.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingRoom>()
                .HasOne(br => br.Booking)
                .WithMany(b => b.BookingRooms)
                .HasForeignKey(br => br.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingRoom>()
                .HasOne(br => br.Room)
                .WithMany(r => r.BookingRooms)
                .HasForeignKey(br => br.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingRoom>()
                .HasKey(br => new {br.BookingId, br.RoomId});
        }
    }
}
