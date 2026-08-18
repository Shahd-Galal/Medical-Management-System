using MedicalManagementSystem.Dtos.Insurance;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Insurance;
using MedicalManagementSystem.Repositories.Insurance;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Insurance
{
    public class InsuranceProviderService : IInsuranceProviderService
    {
        private readonly IInsuranceProviderRepository _insuranceProviderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InsuranceProviderService(IInsuranceProviderRepository insuranceProviderRepository,IUnitOfWork unitOfWork)
        {
            _insuranceProviderRepository = insuranceProviderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<InsuranceProviderResponseDto>> GetAllInsuranceProvidersAsync()
        {
            var providers = await _insuranceProviderRepository.GetAllInsuranceProvidersAsync();

            return providers.Select(p => new InsuranceProviderResponseDto
            {
                InsuranceProviderId = p.InsuranceProviderId,
                Name = p.Name,
                Phone = p.Phone
            });
        }
        public async Task<InsuranceProviderResponseDto> GetInsuranceProviderByIdAsync(int id)
        {
            var provider = await _insuranceProviderRepository.GetInsuranceProviderByIdAsync(id);

            if (provider == null)
                throw new NotFoundException("Insurance provider not found");

            return new InsuranceProviderResponseDto
            {
                InsuranceProviderId = provider.InsuranceProviderId,
                Name = provider.Name,
                Phone = provider.Phone
            };
        }
        public async Task CreateInsuranceProviderAsync(CreateInsuranceProviderDto dto)
        {
            var provider = new InsuranceProvider
            {
                Name = dto.Name,
                Phone = dto.Phone
            };

            await _insuranceProviderRepository.CreateInsuranceProviderAsync(provider);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateInsuranceProviderAsync(int id, UpdateInsuranceProviderDto dto)
        {
            var provider = await _insuranceProviderRepository.GetInsuranceProviderByIdAsync(id);

            if (provider == null)
                throw new NotFoundException("Insurance provider not found");

            provider.Name = dto.Name;
            provider.Phone = dto.Phone;

            await _insuranceProviderRepository.UpdateInsuranceProviderAsync(provider);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteInsuranceProviderByIdAsync(int id)
        {
            var result = await _insuranceProviderRepository.DeleteInsuranceProviderByIdAsync(id);

            if (!result)
                throw new NotFoundException("Insurance provider not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
