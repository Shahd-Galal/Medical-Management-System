using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Billing
{
    public class CreatePaymentDto
    {
        [Required]
        public int InvoiceId { get; set; }
        [Range(0.01, double.MaxValue)] 
        public decimal Amount { get; set; }
        [MaxLength(50)]
        public string? PaymentMethod { get; set; }
    }
}
