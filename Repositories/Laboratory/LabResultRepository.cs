using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Laboratory;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Laboratory
{
    public class LabResultRepository : ILabResultRepository
    {
        private readonly AppDbContext _context;
        public LabResultRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LabResult>> GetAllLabResultsAsync()
        {
            return await _context.LabResults.ToListAsync();
        }
        public async Task<LabResult?> GetLabResultByIdAsync(int id)
        {
            return await _context.LabResults.FirstOrDefaultAsync(l => l.LabResultId == id);
        }
        public async Task<LabResult?> GetLabResultByLabRequestIdAsync(int labRequestId)
        {
            return await _context.LabResults.FirstOrDefaultAsync(l => l.LabRequestId == labRequestId);
        }
        public async Task CreateLabResultAsync(LabResult labResult)
        {
            await _context.LabResults.AddAsync(labResult);
        }
        public async Task UpdateLabResultAsync(LabResult labResult)
        {
            _context.LabResults.Update(labResult);
        }
        public async Task<bool> DeleteLabResultByIdAsync(int id)
        {
            var labResult = await _context.LabResults.FirstOrDefaultAsync(l => l.LabResultId == id);

            if (labResult == null)
                return false;

            labResult.IsDeleted = true;
            return true;
        }
    }
}