using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Enums.Patients;
using MedicalManagementSystem.Model.Auth;
namespace MedicalManagementSystem.Model.Patients
{
    public class Patient : SoftDeletableEntity
    {
        [Key]
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public DateTime DOB { get; set; }
        public Gender? Gender { get; set; }
        public BloodType? BloodType { get; set; }
        [MaxLength(300)]
        public string? Address { get; set; }
        [MaxLength(20)]
        public string? EmergencyContact { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
