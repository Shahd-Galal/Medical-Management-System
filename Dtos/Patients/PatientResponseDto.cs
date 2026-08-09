using MedicalManagementSystem.Enums.Patients;

namespace MedicalManagementSystem.Dtos.Patients
{
    public class PatientResponseDto
    {
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public DateTime DOB { get; set; }
        public Gender? Gender { get; set; }
        public BloodType? BloodType { get; set; }
        public string? Address { get; set; }
        public string? EmergencyContact { get; set; }
    }
}
