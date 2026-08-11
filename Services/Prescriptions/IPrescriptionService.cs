using MedicalManagementSystem.Dtos.Prescriptions;

namespace MedicalManagementSystem.Services.Prescriptions
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionResponseDto>> GetAllPrescriptionsAsync();
        Task<PrescriptionResponseDto> GetPrescriptionByIdAsync(int id);
        Task CreatePrescriptionAsync(CreatePrescriptionDto dto);
        Task<bool> DeletePrescriptionByIdAsync(int id);
    }
}