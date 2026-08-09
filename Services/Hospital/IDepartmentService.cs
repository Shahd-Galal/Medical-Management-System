using MedicalManagementSystem.Dtos.Hospital;

namespace MedicalManagementSystem.Services.Hospital
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentResponseDto>> GetAllDepartmentsAsync();
        Task<DepartmentResponseDto?> GetDepartmentByIdAsync(int id);
        Task CreateDepartmentAsync(CreateDepartmentDto dto);
        Task UpdateDepartmentAsync(int id, UpdateDepartmentDto dto);
        Task DeleteDepartmentAsync(int id);
    }
}
