using MedicalManagementSystem.Dtos.Prescriptions;

namespace MedicalManagementSystem.Services.Prescriptions
{
    public interface IPrescriptionItemService
    {
        Task<IEnumerable<PrescriptionItemResponseDto>>GetAllPrescriptionItemsAsync();
        Task<PrescriptionItemResponseDto>GetPrescriptionItemByIdAsync(int id);
        Task CreatePrescriptionItemAsync(CreatePrescriptionItemDto dto);
        Task UpdatePrescriptionItemAsync(int id, UpdatePrescriptionItemDto dto);
        Task<bool> DeletePrescriptionItemByIdAsync(int id);
    }
}