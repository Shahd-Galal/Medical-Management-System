using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Abstractions;
using MedicalManagementSystem.Enums.Billing;

namespace MedicalManagementSystem.Model.Billing
{
    public class Payment : SoftDeletableEntity
    {
        [Key]
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
        [MaxLength(50)]
        public PaymentMethod? PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; } 

        [ForeignKey(nameof(InvoiceId))]
        public Invoice Invoice { get; set; } = null!;
    }
}
