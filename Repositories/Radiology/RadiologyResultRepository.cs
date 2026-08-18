using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Radiology;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Radiology
{
    public class RadiologyResultRepository : IRadiologyResultRepository
    {
        private readonly AppDbContext _context;
        public RadiologyResultRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RadiologyResult>> GetAllRadiologyResultsAsync()
        {
            return await _context.RadiologyResults.ToListAsync();
        }
        public async Task<RadiologyResult?> GetRadiologyResultByIdAsync(int id)
        {
            return await _context.RadiologyResults.FirstOrDefaultAsync(r => r.RadiologyResultId == id);
        }
        public async Task CreateRadiologyResultAsync(RadiologyResult radiologyResult)
        {
            await _context.RadiologyResults.AddAsync(radiologyResult);
        }
        public async Task UpdateRadiologyResultAsync(RadiologyResult radiologyResult)
        {
            _context.RadiologyResults.Update(radiologyResult);
        }
        public async Task<bool> DeleteRadiologyResultByIdAsync(int id)
        {
            var radiologyResult = await _context.RadiologyResults.FirstOrDefaultAsync(r => r.RadiologyResultId == id);

            if (radiologyResult == null)
                return false;

            radiologyResult.IsDeleted = true;
            return true;
        }
    }
}
