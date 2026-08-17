using System.ComponentModel.DataAnnotations;

namespace _12Aug.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is mandatory")]
        [StringLength(50)]
        public string Name { get; set; }= string.Empty;
        [Required(ErrorMessage = "Name is mandatory")]
        public string City {  get; set; }=string.Empty;
        [Required(ErrorMessage = "Name is mandatory")]
        [Range(1,300)]
        public ICollection <Room> Rooms { get; set; } = new List<Room>();
    }
}
