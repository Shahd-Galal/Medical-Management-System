using MedicalManagementSystem.Dtos.Laboratory;
using MedicalManagementSystem.Enums.Laboratory;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Laboratory;
using MedicalManagementSystem.Repositories.Laboratory;
using MedicalManagementSystem.Repositories.MedicalRecords;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Laboratory
{
    public class LabRequestService : ILabRequestService
    {
        private readonly ILabRequestRepository _labRequestRepository;
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IUnitOfWork _unitOfWork;
        public LabRequestService(ILabRequestRepository labRequestRepository,IMedicalRecordRepository medicalRecordRepository,IUnitOfWork unitOfWork)
        {
            _labRequestRepository = labRequestRepository;
            _medicalRecordRepository = medicalRecordRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<LabRequestResponseDto>>GetAllLabRequestsAsync()
        {
            var labRequests = await _labRequestRepository.GetAllLabRequestsAsync();

            return labRequests.Select(l => new LabRequestResponseDto
            {
                LabRequestId = l.LabRequestId,
                RecordId = l.RecordId,
                DoctorId = l.DoctorId,
                TestName = l.TestName!,
                Status = l.Status
            });
        }
        public async Task<LabRequestResponseDto>GetLabRequestByIdAsync(int id)
        {
            var labRequest = await _labRequestRepository.GetLabRequestByIdAsync(id);

            if (labRequest == null)
                throw new NotFoundException("Lab request not found");

            return new LabRequestResponseDto
            {
                LabRequestId = labRequest.LabRequestId,
                RecordId = labRequest.RecordId,
                DoctorId = labRequest.DoctorId,
                TestName = labRequest.TestName!,
                Status = labRequest.Status
            };
        }
        public async Task CreateLabRequestAsync(CreateLabRequestDto dto)
        {
            var medicalRecord = await _medicalRecordRepository.GetMedicalRecordByIdAsync(dto.RecordId);

            if (medicalRecord == null)
                throw new NotFoundException("Medical record not found");

            var labRequest = new LabRequest
            {
                RecordId = dto.RecordId,
                DoctorId = medicalRecord.DoctorId,
                TestName = dto.TestName,
                Status = LabRequestStatus.Pending
            };
            await _labRequestRepository.CreateLabRequestAsync(labRequest);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateLabRequestAsync(int id,UpdateLabRequestDto dto)
        {
            var labRequest = await _labRequestRepository.GetLabRequestByIdAsync(id);

            if (labRequest == null)
                throw new NotFoundException("Lab request not found");

            labRequest.TestName = dto.TestName;
            labRequest.Status = dto.Status;

            await _labRequestRepository.UpdateLabRequestAsync(labRequest);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteLabRequestByIdAsync(int id)
        {
            var result = await _labRequestRepository.DeleteLabRequestByIdAsync(id);

            if (!result)
                throw new NotFoundException("Lab request not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}