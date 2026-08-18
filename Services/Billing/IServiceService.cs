using MedicalManagementSystem.Dtos.Billing;

namespace MedicalManagementSystem.Services.Billing
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceResponseDto>> GetAllServicesAsync();
        Task<ServiceResponseDto> GetServiceByIdAsync(int id);
        Task CreateServiceAsync(CreateServiceDto dto);
        Task UpdateServiceAsync(int id, UpdateServiceDto dto);
        Task<bool> DeleteServiceByIdAsync(int id);
    }
}
