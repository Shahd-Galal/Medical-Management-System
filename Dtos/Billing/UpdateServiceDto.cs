using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Billing
{
    public class UpdateServiceDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
