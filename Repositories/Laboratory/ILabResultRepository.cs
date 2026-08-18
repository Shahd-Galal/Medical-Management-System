using MedicalManagementSystem.Model.Laboratory;

namespace MedicalManagementSystem.Repositories.Laboratory
{
    public interface ILabResultRepository
    {
        Task<IEnumerable<LabResult>> GetAllLabResultsAsync();
        Task<LabResult?> GetLabResultByIdAsync(int id);
        Task<LabResult?> GetLabResultByLabRequestIdAsync(int labRequestId);
        Task CreateLabResultAsync(LabResult labResult);
        Task UpdateLabResultAsync(LabResult labResult);
        Task<bool> DeleteLabResultByIdAsync(int id);
    }
}
