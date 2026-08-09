using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.MedicalRecords
{
    public class CreateMedicalRecordDto
    {
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [MaxLength(1000)]
        public string? Diagnosis { get; set; }
        [MaxLength(1000)]
        public string? TreatmentPlan { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }
    }
}
