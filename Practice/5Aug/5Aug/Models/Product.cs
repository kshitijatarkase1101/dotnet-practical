using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5Aug.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }//primary key
        [Required(ErrorMessage ="Product Name is mandatory")]
        [StringLength (50, ErrorMessage ="Max letter for product ,ust be below 50")]
        public string PName { get; set; }
        [Required(ErrorMessage = "Product Price is mandatory")]
        [Range(5,1000000,ErrorMessage ="Price can be between 5 to 1000000")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Product quantity is mandatory")]
        [Range(5, 1000000, ErrorMessage = "Quantity can be between 1 to 1000")]
        public int Quantity {  get; set; }


    }
}
