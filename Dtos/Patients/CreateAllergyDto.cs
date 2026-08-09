using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Enums.Patients;

namespace MedicalManagementSystem.Dtos.Patients
{
    public class CreateAllergyDto
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        [MaxLength(100)]
        public string AllergyName { get; set; } = null!;
        [MaxLength(50)]
        public AllergySeverity? Severity { get; set; }
    }
}
