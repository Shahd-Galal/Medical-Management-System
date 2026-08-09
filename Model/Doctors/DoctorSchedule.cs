using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Abstractions;

namespace MedicalManagementSystem.Models.Doctors;

public class DoctorSchedule : SoftDeletableEntity
{
    [Key]
    public int ScheduleId { get; set; }
    public int DoctorId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    [Range(1,100)]
    public int MaxPatients { get; set; }
    [ForeignKey(nameof(DoctorId))]
    public Doctor Doctor { get; set; } = null!;
}