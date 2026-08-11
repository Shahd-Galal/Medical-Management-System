using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Prescriptions;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Prescriptions
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly AppDbContext _context;
        public PrescriptionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
        {
            return await _context.Prescriptions.ToListAsync();
        }
        public async Task<Prescription?> GetPrescriptionByIdAsync(int id)
        {
            return await _context.Prescriptions.FirstOrDefaultAsync(p => p.PrescriptionId == id);
        }
        public async Task CreatePrescriptionAsync(Prescription prescription)
        {
            await _context.Prescriptions.AddAsync(prescription);
        }
        public async Task UpdatePrescriptionAsync(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
        }
        public async Task<bool> DeletePrescriptionByIdAsync(int id)
        {
            var prescription = await _context.Prescriptions.FirstOrDefaultAsync(p => p.PrescriptionId == id);

            if (prescription == null)
                return false;

            prescription.IsDeleted = true;
            return true;
        }
    }
}