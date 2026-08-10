using MedicalManagementSystem.Dtos.Patients;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Models.Patients;
using MedicalManagementSystem.Repositories.Patients;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Patients
{
    public class AllergyService : IAllergyService
    {
        private readonly IAllergyRepository _allergyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AllergyService(IAllergyRepository allergyRepository, IUnitOfWork unitOfWork)
        {
            _allergyRepository = allergyRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<AllergyResponseDto>> GetAllAllergiesAsync()
        {
            var allergies = await _allergyRepository.GetAllAllergiesAsync();

            return allergies.Select(a => new AllergyResponseDto
            {
                AllergyId = a.AllergyId,
                PatientId = a.PatientId,
                AllergyName = a.AllergyName,
                Severity = a.Severity
            });
        }
        public async Task<AllergyResponseDto> GetAllergyByIdAsync(int id)
        {
            var allergy = await _allergyRepository.GetAllergyByIdAsync(id);

            if (allergy == null)
                throw new NotFoundException("Allergy not found");

            return new AllergyResponseDto
            {
                AllergyId = allergy.AllergyId,
                PatientId = allergy.PatientId,
                AllergyName = allergy.AllergyName,
                Severity = allergy.Severity
            };
        }
        public async Task CreateAllergyAsync(CreateAllergyDto dto)
        {
            var allergy = new Allergy
            {
                PatientId = dto.PatientId,
                AllergyName = dto.AllergyName,
                Severity = dto.Severity
            };

            await _allergyRepository.CreateAllergyAsync(allergy);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateAllergyAsync(int id, UpdateAllergyDto dto)
        {
            var allergy = await _allergyRepository.GetAllergyByIdAsync(id);

            if (allergy == null)
                throw new NotFoundException("Allergy not found");

            allergy.AllergyName = dto.AllergyName;
            allergy.Severity = dto.Severity;

            await _allergyRepository.UpdateAllergyAsync(allergy);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteAllergyByIdAsync(int id)
        {
            var result = await _allergyRepository.DeleteAllergyByIdAsync(id);

            if (!result)
                throw new NotFoundException("Allergy not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}