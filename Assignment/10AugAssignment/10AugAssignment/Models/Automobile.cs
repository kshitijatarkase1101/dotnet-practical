using System.ComponentModel.DataAnnotations;

namespace _10AugAssignment.Models
{
    public class Automobile
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of automobile is required")]
        public string Name {  get; set; }
        [Required(ErrorMessage = "Type of automobile is required")]
        public string Type {  get; set; }
        public string Brand {  get; set; }
    }
}
