using MedicalManagementSystem.Data;
using MedicalManagementSystem.Models.MedicalRecords;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.MedicalRecords
{
    public class VitalSignRepository : IVitalSignRepository
    {
        private readonly AppDbContext _context;
        public VitalSignRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VitalSign>> GetAllVitalSignsAsync()
        {
            return await _context.VitalSigns.ToListAsync();
        }
        public async Task<VitalSign?> GetVitalSignByIdAsync(int id)
        {
            return await _context.VitalSigns.FirstOrDefaultAsync(v => v.VitalSignId == id);
        }
        public async Task CreateVitalSignAsync(VitalSign vitalSign)
        {
            await _context.AddAsync(vitalSign);
        }
        public async Task UpdateVitalSignAsync(VitalSign vitalSign)
        {
            _context.Update(vitalSign);
        }
        public async Task<bool> DeleteVitalSignByIdAsync(int id)
        {
            var vitalSign = await _context.VitalSigns.FirstOrDefaultAsync(v => v.VitalSignId == id);

            if (vitalSign == null)
                return false;

            vitalSign.IsDeleted = true;
            return true;
        }
    }
}
