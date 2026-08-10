using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.MedicalRecords;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.MedicalRecords
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly AppDbContext _context;
        public MedicalRecordRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync()
        {
            return await _context.MedicalRecords.ToListAsync();
        }
        public async Task<MedicalRecord?> GetMedicalRecordByIdAsync(int id)
        {
            return await _context.MedicalRecords.FirstOrDefaultAsync(m => m.MedicalRecordId == id);
        }
        public async Task CreateMedicalRecordAsync(MedicalRecord medicalRecord)
        {
             await _context.MedicalRecords.AddAsync(medicalRecord);
        }
        public async Task UpdateMedicalRecordAsync(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Update(medicalRecord);
        }
        public async Task<bool> DeleteMedicalRecordByIdAsync(int id)
        {
            var medicalRecord = await _context.MedicalRecords.FirstOrDefaultAsync(a => a.MedicalRecordId == id);

            if (medicalRecord == null)
                return false;

            medicalRecord.IsDeleted = true;
            return true;
        }
    }
}
