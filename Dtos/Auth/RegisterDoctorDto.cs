using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Auth
{
    public class RegisterDoctorDto
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
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
