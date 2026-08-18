using MedicalManagementSystem.Dtos.Laboratory;

namespace MedicalManagementSystem.Services.Laboratory
{
    public interface ILabResultService
    {
        Task<IEnumerable<LabResultResponseDto>> GetAllLabResultsAsync();
        Task<LabResultResponseDto> GetLabResultByIdAsync(int id);
        Task CreateLabResultAsync(CreateLabResultDto dto);
        Task UpdateLabResultAsync(int id, UpdateLabResultDto dto);
        Task<bool> DeleteLabResultByIdAsync(int id);
    }
}
