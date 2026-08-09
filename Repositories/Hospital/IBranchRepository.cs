using MedicalManagementSystem.Model.Hospital;

namespace MedicalManagementSystem.Repositories.Hospital
{
    public interface IBranchRepository
    {
        Task<IEnumerable<Branch>> GetAllBranchesAsync();
        Task<Branch?> GetBranchByIdAsync(int id);
        Task CreateBranchAsync(Branch branch);
        Task UpdateBranchAsync(Branch branch);
        Task<bool> DeleteBranchByIdAsync(int id);
    }
}
