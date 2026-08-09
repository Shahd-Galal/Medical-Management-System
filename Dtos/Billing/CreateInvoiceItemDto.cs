using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Billing
{
    public class CreateInvoiceItemDto
    {
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
