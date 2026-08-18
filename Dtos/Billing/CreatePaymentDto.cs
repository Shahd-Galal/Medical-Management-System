using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Enums.Billing;

namespace MedicalManagementSystem.Dtos.Billing
{
    public class CreatePaymentDto
    {
        [Required]
        public int InvoiceId { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
    }
}
