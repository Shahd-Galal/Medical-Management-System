using MedicalManagementSystem.Data;
using MedicalManagementSystem.Models.Doctors;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Doctors
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;


        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == id);
        }

        public async Task CreateDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }

        public async Task<bool> DeleteDoctorByIdAsync(int id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == id);

            if (doctor == null)
                return false;

            doctor.IsDeleted = true;
            return true;
        }
    }
}