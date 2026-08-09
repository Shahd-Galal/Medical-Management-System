using MedicalManagementSystem.Enums.Patients;

namespace MedicalManagementSystem.Dtos.Patients
{
    public class AllergyResponseDto
    {
        public int AllergyId { get; set; }
        public int PatientId { get; set; }
        public string AllergyName { get; set; } = null!;
        public AllergySeverity? Severity { get; set; }
    }
}
