using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Abstractions;

namespace MedicalManagementSystem.Model.Billing
{
    public class InvoiceItem : SoftDeletableEntity
    {
        [Key]
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public int ServiceId { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Range(0, int.MaxValue)]
        public decimal UnitPrice { get; set; }
        [Range(0, int.MaxValue)]
        public decimal TotalPrice { get; set; }
        [ForeignKey(nameof(InvoiceId))]
        public Invoice Invoice { get; set; } = null!;
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; } = null!;
    }
}