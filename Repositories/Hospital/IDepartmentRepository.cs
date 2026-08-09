using MedicalManagementSystem.Model.Hospital;

namespace MedicalManagementSystem.Repositories.Hospital
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task CreateDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task<bool> DeleteDepartmentByIdAsync(int id);
    }
}
