using MedicalManagementSystem.Dtos.Hospital;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Hospital;
using MedicalManagementSystem.Repositories.Hospital;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Hospital
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public BranchService(IBranchRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<BranchResponseDto>> GetAllBranchesAsync()
        {
            var branches = await _repository.GetAllBranchesAsync();

            return branches.Select(b => new BranchResponseDto
            {
                BranchId = b.BranchId,
                Name = b.Name,
                Address = b.Address,
                Phone = b.Phone
            });
        }
        public async Task<BranchResponseDto> GetBranchByIdAsync(int id)
        {
            var branch = await _repository.GetBranchByIdAsync(id);

            if (branch == null)
                throw new NotFoundException("Branch not found.");

            return new BranchResponseDto
            {
                BranchId = branch.BranchId,
                Name = branch.Name,
                Address = branch.Address,
                Phone = branch.Phone
            };
        }
        public async Task CreateBranchAsync(CreateBranchDto dto)
        {
            var branch = new Branch
            {
                Name = dto.Name,
                Address = dto.Address,
                Phone = dto.Phone
            };

            await _repository.CreateBranchAsync(branch);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateBranchAsync(int id, UpdateBranchDto dto)
        {
            var branch = await _repository.GetBranchByIdAsync(id);

            if (branch == null)
                throw new NotFoundException("Branch not found.");

            branch.Name = dto.Name;
            branch.Address = dto.Address;
            branch.Phone = dto.Phone;

            await _repository.UpdateBranchAsync(branch);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBranchAsync(int id)
        {
            var deleted = await _repository.DeleteBranchByIdAsync(id);

            if (!deleted)
                throw new NotFoundException("Branch not found.");

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
