using System.ComponentModel.DataAnnotations;

namespace _12Aug.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="HotelId is mandatory")]
        public int HotelId {  get; set; }
        [Required(ErrorMessage = "RoomNumber is mandatory")]
        public int RoomNumber {  get; set; }
        [Required(ErrorMessage = "RoomType is mandatory")]
        public string RoomType {  get; set; }
        [Required(ErrorMessage = "Price is mandatory")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Hotel is mandatory")]
        public Hotel? Hotel {  get; set; }
        [Required(ErrorMessage = "BookingRoom is mandatory")]
        
        public ICollection<BookingRoom> BookingRooms { get; set; }= new List<BookingRoom>();


        
    }
}
