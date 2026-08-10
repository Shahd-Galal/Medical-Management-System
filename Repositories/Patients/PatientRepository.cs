using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Patients;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == id);
        }

        public async Task CreatePatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _context.Patients.Update(patient);
        }

        public async Task<bool> DeletePatientByIdAsync(int id)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.PatientId == id);

            if (patient == null)
                return false;

            patient.IsDeleted = true;
            return true;
        }
    }
}