using MedicalManagementSystem.Model.Prescriptions;

namespace MedicalManagementSystem.Repositories.Prescriptions
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();
        Task<Prescription?> GetPrescriptionByIdAsync(int id);
        Task CreatePrescriptionAsync(Prescription prescription);
        Task UpdatePrescriptionAsync(Prescription prescription);
        Task<bool> DeletePrescriptionByIdAsync(int id);
    }
}