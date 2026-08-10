using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Enums.Appointment;

namespace MedicalManagementSystem.Dtos.Appointments
{
    public class CreateAppointmentDto
    {
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
    }
}
