using _10Aug.Models;

namespace _10Aug.Repository
{
    public interface IBookingService
    {
        Booking CreateBooking(Booking booking);
        List<Booking> GetBooking();
        Booking? GetBookingById(int id);
    }
}
