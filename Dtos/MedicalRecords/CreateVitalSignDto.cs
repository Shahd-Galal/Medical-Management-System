using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.MedicalRecords
{
    public class CreateVitalSignDto
    {
        [Required]
        public int RecordId { get; set; }
        [Range(30, 45)]
        public decimal? Temperature { get; set; }
        [MaxLength(20)]
        public string? BloodPressure { get; set; }
        [Range(30, 250)]
        public int? Pulse { get; set; }
        [Range(5, 60)]
        public int? RespiratoryRate { get; set; }
        [Range(0, 500)]
        public decimal? Weight { get; set; }
        [Range(20, 250)]
        public decimal? Height { get; set; }
    }
}
