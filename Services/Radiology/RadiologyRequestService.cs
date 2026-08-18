using MedicalManagementSystem.Dtos.Radiology;
using MedicalManagementSystem.Enums.Radiology;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Radiology;
using MedicalManagementSystem.Repositories.MedicalRecords;
using MedicalManagementSystem.Repositories.Radiology;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Radiology
{
    public class RadiologyRequestService : IRadiologyRequestService
    {
        private readonly IRadiologyRequestRepository _radiologyRequestRepository;
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RadiologyRequestService(IRadiologyRequestRepository radiologyRequestRepository,IMedicalRecordRepository medicalRecordRepository,IUnitOfWork unitOfWork)
        {
            _radiologyRequestRepository = radiologyRequestRepository;
            _medicalRecordRepository = medicalRecordRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<RadiologyRequestResponseDto>> GetAllRadiologyRequestsAsync()
        {
            var radiologyRequests = await _radiologyRequestRepository.GetAllRadiologyRequestsAsync();

            return radiologyRequests.Select(r => new RadiologyRequestResponseDto
            {
                RadiologyRequestId = r.RadiologyRequestId,
                RecordId = r.RecordId,
                DoctorId = r.DoctorId,
                ScanType = r.ScanType,
                Status = r.Status
            });
        }
        public async Task<RadiologyRequestResponseDto> GetRadiologyRequestByIdAsync(int id)
        {
            var radiologyRequest = await _radiologyRequestRepository.GetRadiologyRequestByIdAsync(id);

            if (radiologyRequest == null)
                throw new NotFoundException("Radiology request not found");

            return new RadiologyRequestResponseDto
            {
                RadiologyRequestId = radiologyRequest.RadiologyRequestId,
                RecordId = radiologyRequest.RecordId,
                DoctorId = radiologyRequest.DoctorId,
                ScanType = radiologyRequest.ScanType,
                Status = radiologyRequest.Status
            };
        }
        public async Task CreateRadiologyRequestAsync(CreateRadiologyRequestDto dto)
        {
            var medicalRecord = await _medicalRecordRepository.GetMedicalRecordByIdAsync(dto.RecordId);

            if (medicalRecord == null)
                throw new NotFoundException("Medical record not found");

            var radiologyRequest = new RadiologyRequest
            {
                RecordId = dto.RecordId,
                DoctorId = medicalRecord.DoctorId,
                ScanType = dto.ScanType,
                Status = RadiologyRequestStatus.Pending
            };

            await _radiologyRequestRepository.CreateRadiologyRequestAsync(radiologyRequest);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateRadiologyRequestAsync(int id, UpdateRadiologyRequestDto dto)
        {
            var radiologyRequest = await _radiologyRequestRepository.GetRadiologyRequestByIdAsync(id);

            if (radiologyRequest == null)
                throw new NotFoundException("Radiology request not found");

            radiologyRequest.ScanType = dto.ScanType;
            radiologyRequest.Status = dto.Status;

            await _radiologyRequestRepository.UpdateRadiologyRequestAsync(radiologyRequest);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteRadiologyRequestByIdAsync(int id)
        {
            var result = await _radiologyRequestRepository.DeleteRadiologyRequestByIdAsync(id);

            if (!result)
                throw new NotFoundException("Radiology request not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
