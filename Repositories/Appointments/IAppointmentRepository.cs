using MedicalManagementSystem.Model.Appointments;

namespace MedicalManagementSystem.Repositories.Appointments
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment?> GetAppointmentByIdAsync(int id);
        Task CreateAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task<bool> DeleteAppointmentByIdAsync(int id);
    }
}