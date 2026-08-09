using MedicalManagementSystem.Enums.Billing;

namespace MedicalManagementSystem.Dtos.Billing
{
    public class InvoiceResponseDto
    {
        public int InvoiceId { get; set; }
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        public decimal TotalAmount { get; set; }
        public InvoiceStatus Status { get; set; } 
    }
}
