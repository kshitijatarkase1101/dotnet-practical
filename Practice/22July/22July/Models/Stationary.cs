using System.ComponentModel.DataAnnotations;

namespace _22July.Models
{
    public class Stationary
    {
        [Required (ErrorMessage ="ID is compulsory")]  public int Id { get; set; }

        [Required(ErrorMessage = "ID is compulsory")] public string Name { get; set; }
        [Required(ErrorMessage = "ID is compulsory")] public int Quantity {  get; set; }
        [Required(ErrorMessage = "ID is compulsory")] [Range(10,10000)] public int Price {  get; set; }
    }
}
