using MedicalManagementSystem.Model.Radiology;

namespace MedicalManagementSystem.Repositories.Radiology
{
    public interface IRadiologyResultRepository
    {
        Task<IEnumerable<RadiologyResult>> GetAllRadiologyResultsAsync();
        Task<RadiologyResult?> GetRadiologyResultByIdAsync(int id);
        Task CreateRadiologyResultAsync(RadiologyResult radiologyResult);
        Task UpdateRadiologyResultAsync(RadiologyResult radiologyResult);
        Task<bool> DeleteRadiologyResultByIdAsync(int id);
    }
}
