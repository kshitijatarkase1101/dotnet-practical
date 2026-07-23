using System.ComponentModel.DataAnnotations;

namespace _22JulyAssignment.Models
{
    public class Automobile
    {
        [Required(ErrorMessage ="Vehicle ID is mandatory")]
        public int VehicleId {  get; set; }
        [Required(ErrorMessage = "Vehicle Name is mandatory")]
        public string VehicleName {  get; set; }
        [Required(ErrorMessage = "Brand is mandatory")]
        public string Brand {  get; set; }
        [Required(ErrorMessage = "Model Year is mandatory")]
        public int ModelYear { get; set; }
        [Required(ErrorMessage = "Price is mandatory")]
        public int Price {  get; set; }
        [Required(ErrorMessage = "Fuel Price is mandatory")]
        public string FuelType {  get; set; }


    }
}
