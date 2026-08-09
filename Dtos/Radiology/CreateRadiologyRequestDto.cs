using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Radiology
{
    public class CreateRadiologyRequestDto
    {
        [Required]
        public int RecordId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ScanType { get; set; } = null!;
    }
}
