using MedicalManagementSystem.Dtos.Laboratory;

namespace MedicalManagementSystem.Services.Laboratory
{
    public interface ILabRequestService
    {
        Task<IEnumerable<LabRequestResponseDto>> GetAllLabRequestsAsync();
        Task<LabRequestResponseDto> GetLabRequestByIdAsync(int id);
        Task CreateLabRequestAsync(CreateLabRequestDto dto);
        Task UpdateLabRequestAsync(int id, UpdateLabRequestDto dto);
        Task<bool> DeleteLabRequestByIdAsync(int id);
    }
}
