using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Enums.Radiology;

namespace MedicalManagementSystem.Dtos.Radiology
{
    public class UpdateRadiologyRequestDto
    {
        [Required]
        [MaxLength(100)]
        public string ScanType { get; set; } = null!;
        [Required]
        public RadiologyRequestStatus Status { get; set; } 
    }
}
