namespace MedicalManagementSystem.Dtos.Doctors
{
    public class DoctorScheduleResponseDto
    {
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int MaxPatients { get; set; }
    }
}
