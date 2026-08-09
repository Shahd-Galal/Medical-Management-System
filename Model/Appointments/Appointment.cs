using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Abstractions;
using MedicalManagementSystem.Enums.Appointment;
using MedicalManagementSystem.Model.Hospital;
using MedicalManagementSystem.Model.Patients;
using MedicalManagementSystem.Models.Doctors;

namespace MedicalManagementSystem.Model.Appointments
{
    public class Appointment : SoftDeletableEntity
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int ScheduleId { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public AppointmentStatus Status { get; set; }
        [MaxLength(500)]
        public string? Reason { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; } = null!;
        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; } = null!;
        [ForeignKey(nameof(ScheduleId))]
        public DoctorSchedule Schedule { get; set; } = null!;
    }
}
