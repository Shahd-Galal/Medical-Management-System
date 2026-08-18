using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Insurance;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Insurance
{
    public class PatientInsuranceRepository : IPatientInsuranceRepository
    {
        private readonly AppDbContext _context;

        public PatientInsuranceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PatientInsurance>> GetAllPatientInsurancesAsync()
        {
            return await _context.PatientInsurances.ToListAsync();
        }
        public async Task<PatientInsurance?> GetPatientInsuranceByIdAsync(int id)
        {
            return await _context.PatientInsurances.FirstOrDefaultAsync(p => p.PatientInsuranceId == id);
        }
        public async Task CreatePatientInsuranceAsync(PatientInsurance patientInsurance)
        {
            await _context.PatientInsurances.AddAsync(patientInsurance);
        }
        public async Task UpdatePatientInsuranceAsync(PatientInsurance patientInsurance)
        {
            _context.PatientInsurances.Update(patientInsurance);
        }
        public async Task<bool> DeletePatientInsuranceByIdAsync(int id)
        {
            var patientInsurance = await _context.PatientInsurances.FirstOrDefaultAsync(p => p.PatientInsuranceId == id);

            if (patientInsurance == null)
                return false;

            patientInsurance.IsDeleted = true;
            return true;
        }
    }
}
