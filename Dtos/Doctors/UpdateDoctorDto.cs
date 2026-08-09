using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Doctors
{
    public class UpdateDoctorDto
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        [MaxLength(50)]
        public string LicenseNumber { get; set; } = null!;
        [Range(0, 70)]
        public int ExperienceYears { get; set; }
        [Range(0, double.MaxValue)]
        public decimal ConsultationFee { get; set; }
    }
}
