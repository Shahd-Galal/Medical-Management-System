using MedicalManagementSystem.Dtos.Radiology;

namespace MedicalManagementSystem.Services.Radiology
{
    public interface IRadiologyResultService
    {
        Task<IEnumerable<RadiologyResultResponseDto>> GetAllRadiologyResultsAsync();
        Task<RadiologyResultResponseDto> GetRadiologyResultByIdAsync(int id);
        Task CreateRadiologyResultAsync(CreateRadiologyResultDto dto);
        Task UpdateRadiologyResultAsync(int id, UpdateRadiologyResultDto dto);
        Task<bool> DeleteRadiologyResultByIdAsync(int id);
    }
}
