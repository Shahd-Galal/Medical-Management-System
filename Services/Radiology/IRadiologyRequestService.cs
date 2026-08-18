using MedicalManagementSystem.Dtos.Radiology;

namespace MedicalManagementSystem.Services.Radiology
{
    public interface IRadiologyRequestService
    {
        Task<IEnumerable<RadiologyRequestResponseDto>> GetAllRadiologyRequestsAsync();
        Task<RadiologyRequestResponseDto> GetRadiologyRequestByIdAsync(int id);
        Task CreateRadiologyRequestAsync(CreateRadiologyRequestDto dto);
        Task UpdateRadiologyRequestAsync(int id, UpdateRadiologyRequestDto dto);
        Task<bool> DeleteRadiologyRequestByIdAsync(int id);
    }
}
