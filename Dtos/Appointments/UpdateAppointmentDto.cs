using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Enums.Appointment;

namespace MedicalManagementSystem.Dtos.Appointments
{
    public class UpdateAppointmentDto
    {
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [MaxLength(20)]
        public AppointmentStatus Status { get; set; } 
        [MaxLength(500)]
        public string? Reason { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }
    }
}
