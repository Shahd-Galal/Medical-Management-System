using MedicalManagementSystem.Dtos.Insurance;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Insurance;
using MedicalManagementSystem.Repositories.Insurance;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Insurance
{
    public class PatientInsuranceService : IPatientInsuranceService
    {
        private readonly IPatientInsuranceRepository _patientInsuranceRepository;
        private readonly IInsuranceProviderRepository _insuranceProviderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PatientInsuranceService(IPatientInsuranceRepository patientInsuranceRepository,IInsuranceProviderRepository insuranceProviderRepository,IUnitOfWork unitOfWork)
        {
            _patientInsuranceRepository = patientInsuranceRepository;
            _insuranceProviderRepository = insuranceProviderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PatientInsuranceResponseDto>> GetAllPatientInsurancesAsync()
        {
            var patientInsurances = await _patientInsuranceRepository.GetAllPatientInsurancesAsync();

            return patientInsurances.Select(p => new PatientInsuranceResponseDto
            {
                PatientInsuranceId = p.PatientInsuranceId,
                PatientId = p.PatientId,
                InsuranceProviderId = p.InsuranceProviderId,
                PolicyNumber = p.PolicyNumber,
                ExpiryDate = p.ExpiryDate
            });
        }
        public async Task<PatientInsuranceResponseDto> GetPatientInsuranceByIdAsync(int id)
        {
            var patientInsurance = await _patientInsuranceRepository.GetPatientInsuranceByIdAsync(id);

            if (patientInsurance == null)
                throw new NotFoundException("Patient insurance not found");

            return new PatientInsuranceResponseDto
            {
                PatientInsuranceId = patientInsurance.PatientInsuranceId,
                PatientId = patientInsurance.PatientId,
                InsuranceProviderId = patientInsurance.InsuranceProviderId,
                PolicyNumber = patientInsurance.PolicyNumber,
                ExpiryDate = patientInsurance.ExpiryDate
            };
        }
        public async Task CreatePatientInsuranceAsync(CreatePatientInsuranceDto dto)
        {
            var provider = await _insuranceProviderRepository
                .GetInsuranceProviderByIdAsync(dto.InsuranceProviderId);

            if (provider == null)
                throw new NotFoundException("Insurance provider not found");

            var patientInsurance = new PatientInsurance
            {
                PatientId = dto.PatientId,
                InsuranceProviderId = dto.InsuranceProviderId,
                PolicyNumber = dto.PolicyNumber,
                ExpiryDate = dto.ExpiryDate
            };

            await _patientInsuranceRepository.CreatePatientInsuranceAsync(patientInsurance);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdatePatientInsuranceAsync(int id, UpdatePatientInsuranceDto dto)
        {
            var patientInsurance = await _patientInsuranceRepository.GetPatientInsuranceByIdAsync(id);

            if (patientInsurance == null)
                throw new NotFoundException("Patient insurance not found");

            patientInsurance.InsuranceProviderId = dto.InsuranceProviderId;
            patientInsurance.PolicyNumber = dto.PolicyNumber;
            patientInsurance.ExpiryDate = dto.ExpiryDate;

            await _patientInsuranceRepository.UpdatePatientInsuranceAsync(patientInsurance);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeletePatientInsuranceByIdAsync(int id)
        {
            var result = await _patientInsuranceRepository.DeletePatientInsuranceByIdAsync(id);

            if (!result)
                throw new NotFoundException("Patient insurance not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
