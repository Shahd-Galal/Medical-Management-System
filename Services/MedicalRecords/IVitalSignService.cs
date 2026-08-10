using MedicalManagementSystem.Dtos.MedicalRecords;

namespace MedicalManagementSystem.Services.MedicalRecords
{
    public interface IVitalSignService
    {
        Task<IEnumerable<VitalSignResponseDto>> GetAllVitalSignsAsync();
        Task<VitalSignResponseDto> GetVitalSignByIdAsync(int id);
        Task CreateVitalSignAsync(CreateVitalSignDto dto);
        Task UpdateVitalSignAsync(int id, UpdateVitalSignDto dto);
        Task<bool> DeleteVitalSignByIdAsync(int id);
    }
}
