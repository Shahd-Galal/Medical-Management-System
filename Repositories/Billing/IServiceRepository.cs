using MedicalManagementSystem.Model.Billing;

namespace MedicalManagementSystem.Repositories.Billing
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service?> GetServiceByIdAsync(int id);
        Task CreateServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task<bool> DeleteServiceByIdAsync(int id);
    }
}
