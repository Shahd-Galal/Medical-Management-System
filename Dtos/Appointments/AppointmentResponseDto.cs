using MedicalManagementSystem.Enums.Appointment;

namespace MedicalManagementSystem.Dtos.Appointments
{
    public class AppointmentResponseDto
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; } 
        public string? Reason { get; set; }
        public string? Notes { get; set; }
    }
}
