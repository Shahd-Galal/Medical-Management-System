using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Hospital;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Hospital
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.Where(d => !d.IsDeleted).ToListAsync();
        }
        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id && !d.IsDeleted);
        }
        public async Task CreateDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
        }
        public async Task UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
        }
        public async Task<bool> DeleteDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id && !d.IsDeleted);

            if (department == null)
                return false;

            department.IsDeleted = true;
            return true;
        }
    }
}
