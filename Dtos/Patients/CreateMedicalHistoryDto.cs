using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Patients
{
    public class CreateMedicalHistoryDto
    {
        [Required]
        public int PatientId { get; set; }
        [MaxLength(200)]
        public string? Disease { get; set; }
        [MaxLength(200)]
        public string? Surgery { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
