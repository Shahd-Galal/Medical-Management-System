using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Enums.Billing;

namespace MedicalManagementSystem.Dtos.Billing
{
    public class CreateInvoiceDto
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public InvoiceStatus Status { get; set; } 
    }
}
