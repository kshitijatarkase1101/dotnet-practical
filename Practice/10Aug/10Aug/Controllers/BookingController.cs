using _10Aug.Models;
using _10Aug.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10Aug.Controllers
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

        // GET: api/Booking
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var bookings = service.GetBooking();

                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while getting bookings.",
                    error = ex.Message
                });
            }
        }


        // GET: api/Booking/1
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                var booking = service.GetBookingById(id);

                if (booking == null)
                {
                    return NotFound(new
                    {
                        message = "Booking not found"
                    });
                }

                return Ok(booking);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while getting the booking.",
                    error = ex.Message
                });
            }
        }


        // POST: api/Booking
        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            try
            {
                var result = service.CreateBooking(booking);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while creating the booking.",
                    error = ex.Message
                });
            }
        }
    }
}