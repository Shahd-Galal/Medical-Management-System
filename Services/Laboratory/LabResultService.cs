using MedicalManagementSystem.Dtos.Laboratory;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Laboratory;
using MedicalManagementSystem.Repositories.Laboratory;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Laboratory
{
    public class LabResultService : ILabResultService
    {
        private readonly ILabResultRepository _labResultRepository;
        private readonly ILabRequestRepository _labRequestRepository;
        private readonly IUnitOfWork _unitOfWork;
        public LabResultService(ILabResultRepository labResultRepository,ILabRequestRepository labRequestRepository,IUnitOfWork unitOfWork)
        {
            _labResultRepository = labResultRepository;
            _labRequestRepository = labRequestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LabResultResponseDto>> GetAllLabResultsAsync()
        {
            var labResults = await _labResultRepository.GetAllLabResultsAsync();

            return labResults.Select(l => new LabResultResponseDto
            {
                LabResultId = l.LabResultId,
                LabRequestId = l.LabRequestId,
                Result = l.Result,
                Notes = l.Notes,
                Attachment = l.Attachment,
                ResultDate = l.ResultDate
            });
        }

        public async Task<LabResultResponseDto> GetLabResultByIdAsync(int id)
        {
            var labResult = await _labResultRepository.GetLabResultByIdAsync(id);

            if (labResult == null)
                throw new NotFoundException("Lab result not found");

            return new LabResultResponseDto
            {
                LabResultId = labResult.LabResultId,
                LabRequestId = labResult.LabRequestId,
                Result = labResult.Result,
                Notes = labResult.Notes,
                Attachment = labResult.Attachment,
                ResultDate = labResult.ResultDate
            };
        }

        public async Task CreateLabResultAsync(CreateLabResultDto dto)
        {
            var labRequest = await _labRequestRepository.GetLabRequestByIdAsync(dto.LabRequestId);

            if (labRequest == null)
                throw new NotFoundException("Lab request not found");

            var labResult = new LabResult
            {
                LabRequestId = dto.LabRequestId,
                Result = dto.Result,
                Notes = dto.Notes,
                Attachment = dto.Attachment,
                ResultDate = DateTime.UtcNow
            };

            await _labResultRepository.CreateLabResultAsync(labResult);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateLabResultAsync(int id, UpdateLabResultDto dto)
        {
            var labResult = await _labResultRepository.GetLabResultByIdAsync(id);

            if (labResult == null)
                throw new NotFoundException("Lab result not found");

            labResult.Result = dto.Result;
            labResult.Notes = dto.Notes;
            labResult.Attachment = dto.Attachment;

            await _labResultRepository.UpdateLabResultAsync(labResult);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteLabResultByIdAsync(int id)
        {
            var result = await _labResultRepository.DeleteLabResultByIdAsync(id);

            if (!result)
                throw new NotFoundException("Lab result not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
