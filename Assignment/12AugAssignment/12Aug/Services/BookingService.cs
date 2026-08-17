using _12Aug.Data;
using _12Aug.Models;
using _12Aug.Repository;
using Microsoft.EntityFrameworkCore;

namespace _12Aug.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext context;

        public BookingService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Booking> CreateBooking(Booking booking, List<int> roomIds)
        {
            // Find the selected rooms
            var rooms = await context.Rooms
                .Where(r => roomIds.Contains(r.Id))
                .ToListAsync();

            if (rooms.Count != roomIds.Count)
            {
                throw new Exception("One or more rooms do not exist.");
            }

            // Calculate total amount
            decimal totalAmount = 0;

            foreach (var room in rooms)
            {
                totalAmount += room.Price;
            }

            booking.TotalAmount = totalAmount;
            booking.Status = "Confirmed";

            // Add booking
            context.Bookings.Add(booking);

            // Add selected rooms to BookingRoom
            foreach (var room in rooms)
            {
                var bookingRoom = new BookingRoom
                {
                    Booking = booking,
                    RoomId = room.Id,
                    Price = room.Price
                };

                context.BookingRooms.Add(bookingRoom);
            }

            await context.SaveChangesAsync();

            return booking;
        }

        

        public async Task<List<Hotel>> GetAvailableHotels()
        {
            return await context.Hotels
               .Include(h => h.Rooms)
               .ToListAsync();
        }

        public async Task<List<Booking>> GetCustomerBookings(int customerId)
        {
            return await context.Bookings
            .Where(b => b.CustomerId == customerId)
            .Include(b => b.Customer)
            .Include(b => b.BookingRooms)
                .ThenInclude(br => br.Room)
            .ToListAsync();
        }

        public async Task<List<Room>> GetRoomsByHotel(int hotelId)
        {
            return await context.Rooms
                .Where(r => r.HotelId == hotelId)
                .ToListAsync();
        }
    }
}
