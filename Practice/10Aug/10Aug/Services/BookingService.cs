using _10Aug.Data;
using _10Aug.Models;
using _10Aug.Repository;

namespace _10Aug.Services
{
    public class BookingService : IBookingService
    {

        private readonly AppDbContext context;

        public BookingService(AppDbContext context)
        {
            this.context = context;
        }
        public Booking CreateBooking(Booking booking)
        
        {
            if (booking.TravelDate.Date < DateTime.UtcNow.Date)
                throw new ArgumentException(
                    "Travel date cannot be in the past");

            var bus = context.Buses
                .FirstOrDefault(b => b.Id == booking.BusId);

            if (bus == null)
                throw new ArgumentException("Invalid bus");

            if (booking.SeatNumber < 1 ||
                booking.SeatNumber > bus.TotalSeats)
                throw new ArgumentException(
                    $"Seat number must be between 1 and {bus.TotalSeats}");

            var state = context.States
                .FirstOrDefault(s => s.Id == booking.StateId);

            if (state == null)
                throw new ArgumentException(
                    "Invalid destination state");

            var seatAlreadyBooked = context.Bookings.Any(b =>
                b.BusId == booking.BusId &&
                b.SeatNumber == booking.SeatNumber &&
                b.TravelDate.Date == booking.TravelDate.Date);

            if (seatAlreadyBooked)
                throw new ArgumentException(
                    "This seat is already booked");

            context.Bookings.Add(booking);
            context.SaveChanges();

            return booking;
        }
        

        public List<Booking> GetBooking()
        {
            try
            {
                return context.Bookings.ToList();
            }
            catch (Exception)
            {
                throw new Exception(
                    "An error occurred while retrieving bookings."
                );
            }
        }

        public Booking? GetBookingById(int id)
        {
            try
            {
                var booking = context.Bookings.Find(id);

                if (booking == null)
                {
                    throw new KeyNotFoundException(
                        $"Booking with ID {id} was not found."
                    );
                }

                return booking;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception(
                    "An error occurred while retrieving the booking."
                );
            }

        }
    }
}
