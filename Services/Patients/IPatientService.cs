using MedicalManagementSystem.Dtos.Patients;

namespace MedicalManagementSystem.Services.Patients
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync();
        Task<PatientResponseDto> GetPatientByIdAsync(int id);
        Task CreatePatientAsync(CreatePatientDto dto);
        Task UpdatePatientAsync(int id, UpdatePatientDto dto);
        Task<bool> DeletePatientByIdAsync(int id);
    }
}
