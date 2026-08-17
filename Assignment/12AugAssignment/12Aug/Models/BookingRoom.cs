namespace _12Aug.Models
{
    public class BookingRoom
    {
        public int BookingId {  get; set; }
        public int RoomId {  get; set; }
        public int Price {  get; set; }
        public Booking? Booking { get; set; }
        public Room? Room { get; set; }

    }
}
