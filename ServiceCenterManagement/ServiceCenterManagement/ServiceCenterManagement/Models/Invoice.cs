using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ServiceCenterManagement.Models
{
    public class Invoice
    {
        //Primary Key
         public int InvoiceId {  get; set; }

        //foreign Key
         public int  ServiceRequestId {  get; set; }
        
        
        [Required(ErrorMessage ="Invoice Date is required")]
         public DateTime InvoiceDate {  get; set; }
        [Required(ErrorMessage = "LaborCharge is required")]
        public decimal LaborCharge {  get; set; }
        [Required(ErrorMessage = "PartsCharge is required")]
        public decimal PartsCharge {  get; set; }
        [Required(ErrorMessage = "Tax is required")]
        public decimal Tax {  get; set; }
        [Required(ErrorMessage = "Discount  is required")]
        public decimal Discount {  get; set; }
        [Required(ErrorMessage = "Total Amount is required is required")]

        public decimal TotalAmount {  get; set; }
        [Required(ErrorMessage = "Payment Status is required is required")]
        public string PaymentStatus {  get; set; }

        //Navigation Property
        [JsonIgnore]
        public ServiceRequest? ServiceRequest {  get; set; }
        [JsonIgnore]
        public Payment? Payment { get; set; }


    }
}

