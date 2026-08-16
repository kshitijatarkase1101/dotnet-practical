using System.ComponentModel.DataAnnotations;

namespace _10Aug.Models
{
    public class State
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(100)]
        public string StateName { get; set; }
    }
}
