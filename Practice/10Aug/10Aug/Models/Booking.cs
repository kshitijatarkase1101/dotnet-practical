using System.ComponentModel.DataAnnotations;

namespace _10Aug.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int PassengerId {  get; set; }
        public int BusId {  get; set; }
        public int StateId {  get; set; }
        [Required(ErrorMessage ="Date is required")]
          public DateTime TravelDate {  get; set; }
        [Required(ErrorMessage = "Seat no is required")]
        [Range(1, 100, ErrorMessage = "Seat number must be between 1 and 100")]
        public int SeatNumber {  get; set; }
        [Required(ErrorMessage = "Fare is required")]
        public decimal fare {  get; set; }
        public Passenger? Passenger { get; set; }
        public Bus? Bus { get; set; }
        public State? State { get; set; }
    }
}
