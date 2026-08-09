using MedicalManagementSystem.Data;
using MedicalManagementSystem.Models.Doctors;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Doctors
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        private readonly AppDbContext _context;
        public DoctorScheduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorSchedule>> GetAllDoctorSchedulesAsync()
        {
            return await _context.DoctorSchedules.ToListAsync();
        }
        public async Task<DoctorSchedule?> GetDoctorScheduleByIdAsync(int id)
        {
            return await _context.DoctorSchedules.FirstOrDefaultAsync(d => d.ScheduleId == id);
        }
        public async Task CreateDoctorScheduleAsync(DoctorSchedule doctorSchedule)
        {
            await _context.DoctorSchedules.AddAsync(doctorSchedule);
        }
        public async Task UpdateDoctorScheduleAsync(DoctorSchedule doctorSchedule)
        {
            _context.DoctorSchedules.Update(doctorSchedule);
        }
        public async Task<bool> DeleteDoctorScheduleByIdAsync(int id)
        {
            var doctorSchedule = await _context.DoctorSchedules.FirstOrDefaultAsync(d => d.ScheduleId == id);

            if (doctorSchedule == null)
                return false;

            doctorSchedule.IsDeleted = true;
            return true;
        }
    }
}