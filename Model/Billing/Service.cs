using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Abstractions;

namespace MedicalManagementSystem.Model.Billing
{
    public class Service : SoftDeletableEntity
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}