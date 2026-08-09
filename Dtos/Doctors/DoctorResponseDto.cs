namespace MedicalManagementSystem.Dtos.Doctors
{
    public class DoctorResponseDto
    {
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string LicenseNumber { get; set; } = null!;
        public int ExperienceYears { get; set; }
        public decimal ConsultationFee { get; set; }
    }
}
