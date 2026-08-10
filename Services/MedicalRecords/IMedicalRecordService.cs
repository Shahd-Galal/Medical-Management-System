using MedicalManagementSystem.Dtos.MedicalRecords;

namespace MedicalManagementSystem.Services.MedicalRecords
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecordResponseDto>> GetAllMedicalRecordsAsync();
        Task<MedicalRecordResponseDto> GetMedicalRecordByIdAsync(int id);
        Task CreateMedicalRecordAsync(CreateMedicalRecordDto dto);
        Task UpdateMedicalRecordAsync(int id, UpdateMedicalRecordDto dto);
        Task<bool> DeleteMedicalRecordByIdAsync(int id);
    }
}
