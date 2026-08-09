using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Radiology
{
    public class CreateRadiologyResultDto
    {
        [Required]
        public int RadiologyRequestId { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Report { get; set; } = null!;
        [Required]
        [MaxLength(500)]
        public string ImagePath { get; set; } = null!;
    }
}
