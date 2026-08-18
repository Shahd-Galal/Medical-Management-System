using MedicalManagementSystem.Dtos.Insurance;

namespace MedicalManagementSystem.Services.Insurance
{
    public interface IInsuranceProviderService
    {
        Task<IEnumerable<InsuranceProviderResponseDto>> GetAllInsuranceProvidersAsync();
        Task<InsuranceProviderResponseDto> GetInsuranceProviderByIdAsync(int id);
        Task CreateInsuranceProviderAsync(CreateInsuranceProviderDto dto);
        Task UpdateInsuranceProviderAsync(int id, UpdateInsuranceProviderDto dto);
        Task<bool> DeleteInsuranceProviderByIdAsync(int id);
    }
}
