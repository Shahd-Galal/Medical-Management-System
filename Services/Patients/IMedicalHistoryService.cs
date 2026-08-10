using MedicalManagementSystem.Dtos.Patients;

namespace MedicalManagementSystem.Services.Patients
{
    public interface IMedicalHistoryService
    {
        Task<IEnumerable<MedicalHistoryResponseDto>> GetAllMedicalHistoriesAsync();
        Task<MedicalHistoryResponseDto> GetMedicalHistoryByIdAsync(int id);
        Task CreateMedicalHistoryAsync(CreateMedicalHistoryDto dto);
        Task UpdateMedicalHistoryAsync(int id, UpdateMedicalHistoryDto dto);
        Task<bool> DeleteMedicalHistoryByIdAsync(int id);
    }
}