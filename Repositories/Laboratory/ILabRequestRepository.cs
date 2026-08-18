using MedicalManagementSystem.Model.Laboratory;

namespace MedicalManagementSystem.Repositories.Laboratory
{
    public interface ILabRequestRepository
    {
        Task<IEnumerable<LabRequest>> GetAllLabRequestsAsync();
        Task<LabRequest?> GetLabRequestByIdAsync(int id);
        Task CreateLabRequestAsync(LabRequest labRequest);
        Task UpdateLabRequestAsync(LabRequest labRequest);
        Task<bool> DeleteLabRequestByIdAsync(int id);
    }
}
