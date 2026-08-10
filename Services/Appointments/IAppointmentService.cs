using MedicalManagementSystem.Dtos.Appointments;

namespace MedicalManagementSystem.Services.Appointments
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentResponseDto>> GetAllAppointmentsAsync();
        Task<AppointmentResponseDto> GetAppointmentByIdAsync(int id);
        Task CreateAppointmentAsync(CreateAppointmentDto dto);
        Task UpdateAppointmentAsync(int id, UpdateAppointmentDto dto);
        Task<bool> DeleteAppointmentByIdAsync(int id);
    }
}
