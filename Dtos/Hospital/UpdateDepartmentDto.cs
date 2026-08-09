using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Hospital
{
    public class UpdateDepartmentDto
    {
        [Required]
        public int BranchId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
