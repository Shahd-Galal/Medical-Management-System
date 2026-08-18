using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Laboratory;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Laboratory
{
    public class LabRequestRepository : ILabRequestRepository
    {
        private readonly AppDbContext _context;
        public LabRequestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LabRequest>> GetAllLabRequestsAsync()
        {
            return await _context.LabRequests.ToListAsync();
        }
        public async Task<LabRequest?> GetLabRequestByIdAsync(int id)
        {
            return await _context.LabRequests.FirstOrDefaultAsync(l => l.LabRequestId == id);
        }
        public async Task CreateLabRequestAsync(LabRequest labRequest)
        {
            await _context.LabRequests.AddAsync(labRequest);
        }
        public async Task UpdateLabRequestAsync(LabRequest labRequest)
        {
            _context.LabRequests.Update(labRequest);
        }

        public async Task<bool> DeleteLabRequestByIdAsync(int id)
        {
            var labRequest = await _context.LabRequests.FirstOrDefaultAsync(l => l.LabRequestId == id);

            if (labRequest == null)
                return false;

            labRequest.IsDeleted = true;
            return true;
        }
    }
}