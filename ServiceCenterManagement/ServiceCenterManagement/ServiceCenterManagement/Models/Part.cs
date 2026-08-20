using System.ComponentModel.DataAnnotations;

namespace ServiceCenterManagement.Models
{
    public class Part
    {
     
        //Primary Key
          public int PartId {  get; set; }
        [Required(ErrorMessage ="Part Name is required")]
          public string PartName {  get; set; }
        [Required(ErrorMessage = "Part Number is required")]
        public string PartNumber {  get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price {  get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity {  get; set; }
        [Required(ErrorMessage = "Supplier is required")]
        public string Supplier {  get; set; }

        public ICollection<ServicePart> ServiceParts { get; set; }
    }
}
