using MedicalManagementSystem.Models.MedicalRecords;

namespace MedicalManagementSystem.Repositories.MedicalRecords
{
    public interface IVitalSignRepository
    {
        Task<IEnumerable<VitalSign>> GetAllVitalSignsAsync();
        Task<VitalSign?> GetVitalSignByIdAsync(int id);
        Task CreateVitalSignAsync(VitalSign vitalSign);
        Task UpdateVitalSignAsync(VitalSign vitalSign);
        Task<bool> DeleteVitalSignByIdAsync(int id);
    }
}
