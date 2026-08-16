using _12Aug.Models;
using _12Aug.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _12Aug.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService service;

        public BookingController(IBookingService service)
        {
            this.service = service;
        }

        // Get all hotels
        [HttpGet("hotels")]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await service.GetAvailableHotels();

            return Ok(hotels);
        }

        // Get rooms by hotel
        [HttpGet("hotel/{hotelId}/rooms")]
        public async Task<IActionResult> GetRoomsByHotel(int hotelId)
        {
            var rooms = await service.GetRoomsByHotel(hotelId);

            if (rooms == null || rooms.Count == 0)
            {
                return NotFound("No rooms found.");
            }

            return Ok(rooms);
        }

        // Create booking
        [HttpPost]
        public async Task<IActionResult> CreateBooking(
            Booking booking,
             [FromQuery] List<int> roomIds)
        {
            if (roomIds == null || roomIds.Count == 0)
            {
                return BadRequest("Please select at least one room.");
            }

            var result = await service.CreateBooking(booking, roomIds);

            return Ok(result);
        }

        // Get customer bookings
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetCustomerBookings(int customerId)
        {
            var bookings = await service.GetCustomerBookings(customerId);

            if (bookings == null || bookings.Count == 0)
            {
                return NotFound("No bookings found.");
            }

            return Ok(bookings);
        }
    }
}
