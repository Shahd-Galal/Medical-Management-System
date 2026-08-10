using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Patients;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Patients
{
    public class MedicalHistoryRepository : IMedicalHistoryRepository
    {
        private readonly AppDbContext _context;

        public MedicalHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicalHistory>> GetAllMedicalHistoriesAsync()
        {
            return await _context.MedicalHistories.ToListAsync();
        }
        public async Task<MedicalHistory?> GetMedicalHistoryByIdAsync(int id)
        {
            return await _context.MedicalHistories.FirstOrDefaultAsync(m => m.MedicalHistoryId == id);
        }
        public async Task CreateMedicalHistoryAsync(MedicalHistory medicalHistory)
        {
            await _context.MedicalHistories.AddAsync(medicalHistory);
        }
        public async Task UpdateMedicalHistoryAsync(MedicalHistory medicalHistory)
        {
            _context.MedicalHistories.Update(medicalHistory);
        }
        public async Task<bool> DeleteMedicalHistoryByIdAsync(int id)
        {
            var medicalHistory = await _context.MedicalHistories.FirstOrDefaultAsync(m => m.MedicalHistoryId == id);

            if (medicalHistory == null)
                return false;

            medicalHistory.IsDeleted = true;
            return true;
        }
    }
}