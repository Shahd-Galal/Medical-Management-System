using MedicalManagementSystem.Model.Prescriptions;

namespace MedicalManagementSystem.Repositories.Prescriptions
{
    public interface IPrescriptionItemRepository
    {
        Task<IEnumerable<PrescriptionItem>> GetAllPrescriptionItemsAsync();
        Task<PrescriptionItem?> GetPrescriptionItemByIdAsync(int id);
        Task CreatePrescriptionItemAsync(PrescriptionItem prescriptionItem);
        Task UpdatePrescriptionItemAsync(PrescriptionItem prescriptionItem);
        Task<bool> DeletePrescriptionItemByIdAsync(int id);
    }
}