using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Billing;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Billing
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;
        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }
        public async Task<Service?> GetServiceByIdAsync(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.ServiceId == id);
        }
        public async Task CreateServiceAsync(Service service)
        {
            await _context.Services.AddAsync(service);
        }
        public async Task UpdateServiceAsync(Service service)
        {
            _context.Services.Update(service);
        }
        public async Task<bool> DeleteServiceByIdAsync(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.ServiceId == id);

            if (service == null)
                return false;

            service.IsDeleted = true;
            return true;
        }
    }
}
