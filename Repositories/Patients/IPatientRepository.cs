using MedicalManagementSystem.Model.Patients;

namespace MedicalManagementSystem.Repositories.Patients
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient?> GetPatientByIdAsync(int id);
        Task CreatePatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);
        Task<bool> DeletePatientByIdAsync(int id);
    }
}