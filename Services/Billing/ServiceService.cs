using MedicalManagementSystem.Dtos.Billing;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Billing;
using MedicalManagementSystem.Repositories.Billing;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Billing
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ServiceService(IServiceRepository serviceRepository,IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ServiceResponseDto>> GetAllServicesAsync()
        {
            var services = await _serviceRepository.GetAllServicesAsync();

            return services.Select(s => new ServiceResponseDto
            {
                ServiceId = s.ServiceId,
                Name = s.Name,
                Price = s.Price
            });
        }
        public async Task<ServiceResponseDto> GetServiceByIdAsync(int id)
        {
            var service = await _serviceRepository.GetServiceByIdAsync(id);

            if (service == null)
                throw new NotFoundException("Service not found");

            return new ServiceResponseDto
            {
                ServiceId = service.ServiceId,
                Name = service.Name,
                Price = service.Price
            };
        }
        public async Task CreateServiceAsync(CreateServiceDto dto)
        {
            var service = new Service
            {
                Name = dto.Name,
                Price = dto.Price
            };

            await _serviceRepository.CreateServiceAsync(service);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateServiceAsync(int id, UpdateServiceDto dto)
        {
            var service = await _serviceRepository.GetServiceByIdAsync(id);

            if (service == null)
                throw new NotFoundException("Service not found");

            service.Name = dto.Name;
            service.Price = dto.Price;

            await _serviceRepository.UpdateServiceAsync(service);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteServiceByIdAsync(int id)
        {
            var result = await _serviceRepository.DeleteServiceByIdAsync(id);

            if (!result)
                throw new NotFoundException("Service not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
