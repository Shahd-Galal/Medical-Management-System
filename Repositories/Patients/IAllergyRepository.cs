using MedicalManagementSystem.Models.Patients;

namespace MedicalManagementSystem.Repositories.Patients
{
    public interface IAllergyRepository
    {
        Task<IEnumerable<Allergy>> GetAllAllergiesAsync();
        Task<Allergy?> GetAllergyByIdAsync(int id);
        Task CreateAllergyAsync(Allergy allergy);
        Task UpdateAllergyAsync(Allergy allergy);
        Task<bool> DeleteAllergyByIdAsync(int id);
    }
}