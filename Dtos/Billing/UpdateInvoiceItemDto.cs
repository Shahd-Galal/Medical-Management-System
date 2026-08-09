using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Billing
{
    public class UpdateInvoiceItemDto
    {
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
