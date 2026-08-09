using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Hospital;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Hospital
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext _context;

        public BranchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Branch>> GetAllBranchesAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branch?> GetBranchByIdAsync(int id)
        {
            return await _context.Branches.FirstOrDefaultAsync(b => b.BranchId == id);
        }

        public async Task CreateBranchAsync(Branch branch)
        {
            await _context.Branches.AddAsync(branch);
        }

        public async Task UpdateBranchAsync(Branch branch)
        {
            _context.Branches.Update(branch);
        }

        public async Task<bool> DeleteBranchByIdAsync(int id)
        {
            var branch = await _context.Branches.FirstOrDefaultAsync(b => b.BranchId == id);

            if (branch == null)
                return false;

            branch.IsDeleted = true;
            return true;
        }
    }
}
