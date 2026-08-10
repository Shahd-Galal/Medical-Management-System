using MedicalManagementSystem.Model.MedicalRecords;

namespace MedicalManagementSystem.Repositories.MedicalRecords
{
    public interface IMedicalRecordRepository
    {
        Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync();
        Task<MedicalRecord?> GetMedicalRecordByIdAsync(int id);
        Task CreateMedicalRecordAsync(MedicalRecord medicalRecord);
        Task UpdateMedicalRecordAsync(MedicalRecord medicalRecord);
        Task<bool> DeleteMedicalRecordByIdAsync(int id);
    }
}
