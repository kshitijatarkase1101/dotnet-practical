using System.ComponentModel.DataAnnotations;

namespace ServiceCenterManagementMVC.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Payment amount is required")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment date is required")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Payment method is required")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Payment status is required")]
        public string PaymentStatus { get; set; }
    }
}