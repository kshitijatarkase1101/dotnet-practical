using System.ComponentModel.DataAnnotations;

namespace _10AugAssignment.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of company is required")]
        public string Name { get; set; }=string.Empty;
    }
}
