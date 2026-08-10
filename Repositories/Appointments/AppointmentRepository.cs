using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Appointments;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Appointments
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments.ToListAsync();
        }
        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(a => a.AppointmentId == id);
        }
        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }
        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }
        public async Task<bool> DeleteAppointmentByIdAsync(int id)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.AppointmentId == id);

            if (appointment == null)
                return false;

            appointment.IsDeleted = true;
            return true;
        }
    }
}