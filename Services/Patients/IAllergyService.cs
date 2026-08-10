using MedicalManagementSystem.Dtos.Patients;

namespace MedicalManagementSystem.Services.Patients
{
    public interface IAllergyService
    {
        Task<IEnumerable<AllergyResponseDto>> GetAllAllergiesAsync();
        Task<AllergyResponseDto> GetAllergyByIdAsync(int id);
        Task CreateAllergyAsync(CreateAllergyDto dto);
        Task UpdateAllergyAsync(int id, UpdateAllergyDto dto);
        Task<bool> DeleteAllergyByIdAsync(int id);
    }
}