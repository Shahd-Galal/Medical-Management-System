using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Enums.Patients;

namespace MedicalManagementSystem.Dtos.Patients
{
    public class UpdatePatientDto
    {
        [Required]
        public DateTime DOB { get; set; }
        [MaxLength(20)]
        public Gender? Gender { get; set; }
        [MaxLength(5)]
        public BloodType? BloodType { get; set; }
        [MaxLength(300)]
        public string? Address { get; set; }
        [MaxLength(20)]
        public string? EmergencyContact { get; set; }
    }
}
