using MedicalManagementSystem.Dtos.Insurance;

namespace MedicalManagementSystem.Services.Insurance
{
    public interface IPatientInsuranceService
    {
        Task<IEnumerable<PatientInsuranceResponseDto>> GetAllPatientInsurancesAsync();
        Task<PatientInsuranceResponseDto> GetPatientInsuranceByIdAsync(int id);
        Task CreatePatientInsuranceAsync(CreatePatientInsuranceDto dto);
        Task UpdatePatientInsuranceAsync(int id, UpdatePatientInsuranceDto dto);
        Task<bool> DeletePatientInsuranceByIdAsync(int id);
    }
}
