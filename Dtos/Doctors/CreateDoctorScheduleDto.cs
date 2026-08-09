using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Doctors
{
    public class CreateDoctorScheduleDto
    {
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public DayOfWeek DayOfWeek { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Range(1, 100)]
        public int MaxPatients { get; set; }
    }
}
