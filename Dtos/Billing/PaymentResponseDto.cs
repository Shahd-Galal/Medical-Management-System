using MedicalManagementSystem.Enums.Patients;

namespace MedicalManagementSystem.Dtos.Billing
{
    public class PaymentResponseDto
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public BloodType Status { get; set; } 
    }
}
