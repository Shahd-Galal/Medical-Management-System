using MedicalManagementSystem.Enums.Billing;

namespace MedicalManagementSystem.Dtos.Billing
{
    public class PaymentResponseDto
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
