using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Insurance;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Insurance
{
    public class InsuranceProviderRepository : IInsuranceProviderRepository
    {
        private readonly AppDbContext _context;
        public InsuranceProviderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<InsuranceProvider>> GetAllInsuranceProvidersAsync()
        {
            return await _context.InsuranceProviders.ToListAsync();
        }
        public async Task<InsuranceProvider?> GetInsuranceProviderByIdAsync(int id)
        {
            return await _context.InsuranceProviders.FirstOrDefaultAsync(p => p.InsuranceProviderId == id);
        }
        public async Task CreateInsuranceProviderAsync(InsuranceProvider insuranceProvider)
        {
            await _context.InsuranceProviders.AddAsync(insuranceProvider);
        }
        public async Task UpdateInsuranceProviderAsync(InsuranceProvider insuranceProvider)
        {
            _context.InsuranceProviders.Update(insuranceProvider);
        }
        public async Task<bool> DeleteInsuranceProviderByIdAsync(int id)
        {
            var insuranceProvider = await _context.InsuranceProviders.FirstOrDefaultAsync(p => p.InsuranceProviderId == id);

            if (insuranceProvider == null)
                return false;

            insuranceProvider.IsDeleted = true;
            return true;
        }
    }
}
