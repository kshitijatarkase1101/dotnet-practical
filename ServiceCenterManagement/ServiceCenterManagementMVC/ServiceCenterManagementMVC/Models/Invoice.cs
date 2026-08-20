using System.ComponentModel.DataAnnotations;

namespace ServiceCenterManagementMVC.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public int ServiceRequestId { get; set; }

        [Required(ErrorMessage = "Invoice Date is required")]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "Labor Charge is required")]
        public decimal LaborCharge { get; set; }

        [Required(ErrorMessage = "Parts Charge is required")]
        public decimal PartsCharge { get; set; }

        [Required(ErrorMessage = "Tax is required")]
        public decimal Tax { get; set; }

        [Required(ErrorMessage = "Discount is required")]
        public decimal Discount { get; set; }

        [Required(ErrorMessage = "Total Amount is required")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Payment Status is required")]
        public string PaymentStatus { get; set; }
    }
}