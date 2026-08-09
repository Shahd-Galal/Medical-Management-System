using MedicalManagementSystem.Models.Doctors;

namespace MedicalManagementSystem.Repositories.Doctors
{
    public interface IDoctorScheduleRepository
    {
        Task<IEnumerable<DoctorSchedule>> GetAllDoctorSchedulesAsync();
        Task<DoctorSchedule?> GetDoctorScheduleByIdAsync(int id);
        Task CreateDoctorScheduleAsync(DoctorSchedule doctorSchedule);
        Task UpdateDoctorScheduleAsync(DoctorSchedule doctorSchedule);
        Task<bool> DeleteDoctorScheduleByIdAsync(int id);
    }
}
