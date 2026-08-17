using _12Aug.Models;

namespace _12Aug.Repository
{
    public interface IBookingService
    {
       Task< List<Hotel>> GetAvailableHotels();
       Task< List<Room>>GetRoomsByHotel(int hotelId);
        Task<Booking>CreateBooking(Booking booking, List<int> roomIds);
        Task<List<Booking> >GetCustomerBookings(int customerId);
       
    }
}
