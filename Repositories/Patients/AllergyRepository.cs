using MedicalManagementSystem.Data;
using MedicalManagementSystem.Models.Patients;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Patients
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly AppDbContext _context;

        public AllergyRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Allergy>> GetAllAllergiesAsync()
        {
            return await _context.Allergies.ToListAsync();
        }
        public async Task<Allergy?> GetAllergyByIdAsync(int id)
        {
            return await _context.Allergies.FirstOrDefaultAsync(a => a.AllergyId == id);
        }
        public async Task CreateAllergyAsync(Allergy allergy)
        {
            await _context.Allergies.AddAsync(allergy);
        }
        public async Task UpdateAllergyAsync(Allergy allergy)
        {
            _context.Allergies.Update(allergy);
        }
        public async Task<bool> DeleteAllergyByIdAsync(int id)
        {
            var allergy = await _context.Allergies.FirstOrDefaultAsync(a => a.AllergyId == id);

            if (allergy == null)
                return false;

            allergy.IsDeleted = true;
            return true;
        }
    }
}