using MedicalManagementSystem.Dtos.Doctors;

namespace MedicalManagementSystem.Services.Doctors
{
    public interface IDoctorScheduleService
    {
        Task<IEnumerable<DoctorScheduleResponseDto>> GetAllSchedulesAsync();
        Task<DoctorScheduleResponseDto> GetScheduleByIdAsync(int id);
        Task CreateScheduleAsync(CreateDoctorScheduleDto dto);
        Task UpdateScheduleAsync(int id, UpdateDoctorScheduleDto dto);
        Task<bool> DeleteScheduleByIdAsync(int id);
    }
}
