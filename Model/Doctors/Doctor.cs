using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Abstractions;
using MedicalManagementSystem.Model.Auth;
using MedicalManagementSystem.Model.Hospital;

namespace MedicalManagementSystem.Models.Doctors;

public class Doctor : SoftDeletableEntity
{
    [Key]
    public int DoctorId { get; set; }
    public int UserId { get; set; }
    public int DepartmentId { get; set; }
    [Required]
    [MaxLength(50)]
    public string LicenseNumber { get; set; } = null!;
    [Range(0,70)]
    public int ExperienceYears { get; set; }
    [Range(0, double.MaxValue)]
    public decimal ConsultationFee { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
    [ForeignKey(nameof(DepartmentId))]
    public Department Department { get; set; } = null!;
    public ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();
}