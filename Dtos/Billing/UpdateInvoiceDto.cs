using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Enums.Billing;

namespace MedicalManagementSystem.Dtos.Billing
{
    public class UpdateInvoiceDto
    {
        [Required]
        [MaxLength(20)]
        public InvoiceStatus Status { get; set; } 
    }
}
