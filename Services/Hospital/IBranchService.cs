using MedicalManagementSystem.Dtos.Hospital;

namespace MedicalManagementSystem.Services.Hospital
{
    public interface IBranchService
    {
        Task<IEnumerable<BranchResponseDto>> GetAllBranchesAsync();
        Task<BranchResponseDto> GetBranchByIdAsync(int id);
        Task CreateBranchAsync(CreateBranchDto dto);
        Task UpdateBranchAsync(int id, UpdateBranchDto dto);
        Task DeleteBranchAsync(int id);
    }
}
