using MedicalManagementSystem.Dtos.Hospital;
using MedicalManagementSystem.Model.Hospital;
using MedicalManagementSystem.Repositories.Hospital;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Hospital
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IDepartmentRepository departmentRepository,IBranchRepository branchRepository,IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _branchRepository = branchRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DepartmentResponseDto>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();

            return departments.Select(d => new DepartmentResponseDto
            {
                DepartmentId = d.DepartmentId,
                BranchId = d.BranchId,
                Name = d.Name,
                Description = d.Description
            });
        }

        public async Task<DepartmentResponseDto?> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);

            if (department == null)
                throw new Exception("Department not found.");

            return new DepartmentResponseDto
            {
                DepartmentId = department.DepartmentId,
                BranchId = department.BranchId,
                Name = department.Name,
                Description = department.Description
            };
        }

        public async Task CreateDepartmentAsync(CreateDepartmentDto dto)
        {
            var branch = await _branchRepository.GetBranchByIdAsync(dto.BranchId);

            if (branch == null)
                throw new Exception("Branch not found.");

            var department = new Department
            {
                BranchId = dto.BranchId,
                Name = dto.Name,
                Description = dto.Description
            };

            await _departmentRepository.CreateDepartmentAsync(department);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(int id, UpdateDepartmentDto dto)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);

            if (department == null)
                throw new Exception("Department not found.");

            var branch = await _branchRepository.GetBranchByIdAsync(dto.BranchId);

            if (branch == null)
                throw new Exception("Branch not found.");

            department.BranchId = dto.BranchId;
            department.Name = dto.Name;
            department.Description = dto.Description;

            await _departmentRepository.UpdateDepartmentAsync(department);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var deleted = await _departmentRepository.DeleteDepartmentByIdAsync(id);

            if (!deleted)
                throw new Exception("Department not found.");

            await _unitOfWork.SaveChangesAsync();
        }
    }
}