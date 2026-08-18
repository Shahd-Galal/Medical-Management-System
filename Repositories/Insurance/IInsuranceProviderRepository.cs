using MedicalManagementSystem.Model.Insurance;

namespace MedicalManagementSystem.Repositories.Insurance
{
    public interface IInsuranceProviderRepository
    {
        Task<IEnumerable<InsuranceProvider>> GetAllInsuranceProvidersAsync();
        Task<InsuranceProvider?> GetInsuranceProviderByIdAsync(int id);
        Task CreateInsuranceProviderAsync(InsuranceProvider insuranceProvider);
        Task UpdateInsuranceProviderAsync(InsuranceProvider insuranceProvider);
        Task<bool> DeleteInsuranceProviderByIdAsync(int id);
    }
}
