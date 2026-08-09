using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Medicines
{
    public class UpdateMedicineDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(1000)]
        public string? Description { get; set; }
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }
        [MaxLength(100)]
        public string? Manufacturer { get; set; }
    }
}
