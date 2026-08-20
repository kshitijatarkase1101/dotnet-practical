using System.ComponentModel.DataAnnotations;

namespace ServiceCenterManagement.Models
{
    public class Payment
    {
       
            // Primary Key
            public int PaymentId { get; set; }

            // Foreign Key
            public int InvoiceId { get; set; }

            // Navigation Property
            public Invoice Invoice { get; set; }

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

