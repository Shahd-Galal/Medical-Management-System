using MedicalManagementSystem.Model.Insurance;

namespace MedicalManagementSystem.Repositories.Insurance
{
    public interface IPatientInsuranceRepository
    {
        Task<IEnumerable<PatientInsurance>> GetAllPatientInsurancesAsync();
        Task<PatientInsurance?> GetPatientInsuranceByIdAsync(int id);
        Task CreatePatientInsuranceAsync(PatientInsurance patientInsurance);
        Task UpdatePatientInsuranceAsync(PatientInsurance patientInsurance);
        Task<bool> DeletePatientInsuranceByIdAsync(int id);
    }
}
