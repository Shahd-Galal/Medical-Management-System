using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Radiology;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Radiology
{
    public class RadiologyRequestRepository : IRadiologyRequestRepository
    {
        private readonly AppDbContext _context;
        public RadiologyRequestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RadiologyRequest>> GetAllRadiologyRequestsAsync()
        {
            return await _context.RadiologyRequests.ToListAsync();
        }
        public async Task<RadiologyRequest?> GetRadiologyRequestByIdAsync(int id)
        {
            return await _context.RadiologyRequests.FirstOrDefaultAsync(r => r.RadiologyRequestId == id);
        }
        public async Task CreateRadiologyRequestAsync(RadiologyRequest radiologyRequest)
        {
            await _context.RadiologyRequests.AddAsync(radiologyRequest);
        }
        public async Task UpdateRadiologyRequestAsync(RadiologyRequest radiologyRequest)
        {
            _context.RadiologyRequests.Update(radiologyRequest);
        }
        public async Task<bool> DeleteRadiologyRequestByIdAsync(int id)
        {
            var radiologyRequest = await _context.RadiologyRequests.FirstOrDefaultAsync(r => r.RadiologyRequestId == id);

            if (radiologyRequest == null)
                return false;

            radiologyRequest.IsDeleted = true;
            return true;
        }
    }
}
