using MedicalManagementSystem.Dtos.Radiology;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Radiology;
using MedicalManagementSystem.Repositories.Radiology;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Radiology
{
    public class RadiologyResultService : IRadiologyResultService
    {
        private readonly IRadiologyResultRepository _radiologyResultRepository;
        private readonly IRadiologyRequestRepository _radiologyRequestRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RadiologyResultService(IRadiologyResultRepository radiologyResultRepository,IRadiologyRequestRepository radiologyRequestRepository,IUnitOfWork unitOfWork)
        {
            _radiologyResultRepository = radiologyResultRepository;
            _radiologyRequestRepository = radiologyRequestRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<RadiologyResultResponseDto>> GetAllRadiologyResultsAsync()
        {
            var radiologyResults = await _radiologyResultRepository.GetAllRadiologyResultsAsync();

            return radiologyResults.Select(r => new RadiologyResultResponseDto
            {
                RadiologyResultId = r.RadiologyResultId,
                RadiologyRequestId = r.RadiologyRequestId,
                Report = r.Report,
                ImagePath = r.ImagePath,
                ResultDate = r.ResultDate
            });
        }
        public async Task<RadiologyResultResponseDto> GetRadiologyResultByIdAsync(int id)
        {
            var radiologyResult = await _radiologyResultRepository.GetRadiologyResultByIdAsync(id);

            if (radiologyResult == null)
                throw new NotFoundException("Radiology result not found");

            return new RadiologyResultResponseDto
            {
                RadiologyResultId = radiologyResult.RadiologyResultId,
                RadiologyRequestId = radiologyResult.RadiologyRequestId,
                Report = radiologyResult.Report,
                ImagePath = radiologyResult.ImagePath,
                ResultDate = radiologyResult.ResultDate
            };
        }
        public async Task CreateRadiologyResultAsync(CreateRadiologyResultDto dto)
        {
            var radiologyRequest = await _radiologyRequestRepository
                .GetRadiologyRequestByIdAsync(dto.RadiologyRequestId);

            if (radiologyRequest == null)
                throw new NotFoundException("Radiology request not found");

            var radiologyResult = new RadiologyResult
            {
                RadiologyRequestId = dto.RadiologyRequestId,
                Report = dto.Report,
                ImagePath = dto.ImagePath,
                ResultDate = DateTime.UtcNow
            };

            await _radiologyResultRepository.CreateRadiologyResultAsync(radiologyResult);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateRadiologyResultAsync(int id, UpdateRadiologyResultDto dto)
        {
            var radiologyResult = await _radiologyResultRepository.GetRadiologyResultByIdAsync(id);

            if (radiologyResult == null)
                throw new NotFoundException("Radiology result not found");

            radiologyResult.Report = dto.Report;
            radiologyResult.ImagePath = dto.ImagePath;

            await _radiologyResultRepository.UpdateRadiologyResultAsync(radiologyResult);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteRadiologyResultByIdAsync(int id)
        {
            var result = await _radiologyResultRepository.DeleteRadiologyResultByIdAsync(id);

            if (!result)
                throw new NotFoundException("Radiology result not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
