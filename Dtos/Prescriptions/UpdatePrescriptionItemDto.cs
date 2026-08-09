using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Prescriptions
{
    public class UpdatePrescriptionItemDto
    {
        [MaxLength(100)]
        public string? Dosage { get; set; }
        [MaxLength(100)]
        public string? Frequency { get; set; }
        [Range(1, 3650)]
        public int DurationDays { get; set; }
        [MaxLength(500)]
        public string? Instructions { get; set; }
    }
}
