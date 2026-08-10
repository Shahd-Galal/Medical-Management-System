using MedicalManagementSystem.Model.Patients;

namespace MedicalManagementSystem.Repositories.Patients
{
    public interface IMedicalHistoryRepository
    {
        Task<IEnumerable<MedicalHistory>> GetAllMedicalHistoriesAsync();
        Task<MedicalHistory?> GetMedicalHistoryByIdAsync(int id);
        Task CreateMedicalHistoryAsync(MedicalHistory medicalHistory);
        Task UpdateMedicalHistoryAsync(MedicalHistory medicalHistory);
        Task<bool> DeleteMedicalHistoryByIdAsync(int id);
    }
}