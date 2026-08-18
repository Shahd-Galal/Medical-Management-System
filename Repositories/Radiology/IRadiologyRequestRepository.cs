using MedicalManagementSystem.Model.Radiology;

namespace MedicalManagementSystem.Repositories.Radiology
{
    public interface IRadiologyRequestRepository
    {
        Task<IEnumerable<RadiologyRequest>> GetAllRadiologyRequestsAsync();
        Task<RadiologyRequest?> GetRadiologyRequestByIdAsync(int id);
        Task CreateRadiologyRequestAsync(RadiologyRequest radiologyRequest);
        Task UpdateRadiologyRequestAsync(RadiologyRequest radiologyRequest);
        Task<bool> DeleteRadiologyRequestByIdAsync(int id);
    }
}
