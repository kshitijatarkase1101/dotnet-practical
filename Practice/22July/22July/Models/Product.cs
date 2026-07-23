using System.ComponentModel.DataAnnotations;

namespace _22July.Models
{
    public class Product
    {
        public int Id {  get; set; }

        [Required(ErrorMessage ="Name is Mandatory")]
        public string Name {  get; set; }


        [Required(ErrorMessage = "Price is Mandatory")]
        [Range(10,1000000)] 
        public decimal Price {  get; set; }


        [Required(ErrorMessage = "Category is Mandatory")]
        public string Category {  get; set; }

       
        [Required(ErrorMessage = "Stock is Mandatory")] 
        public int Stock {  get; set; }

    }
}
