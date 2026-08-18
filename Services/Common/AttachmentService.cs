using MedicalManagementSystem.Dtos.Common;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Common;
using MedicalManagementSystem.Repositories.Common;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Common
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AttachmentService(IAttachmentRepository attachmentRepository,IUnitOfWork unitOfWork)
        {
            _attachmentRepository = attachmentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<AttachmentResponseDto>> GetAllAttachmentsAsync()
        {
            var attachments = await _attachmentRepository.GetAllAttachmentsAsync();

            return attachments.Select(a => new AttachmentResponseDto
            {
                AttachmentId = a.AttachmentId,
                RecordId = a.RecordId,
                FileName = a.FileName,
                FilePath = a.FilePath,
                FileType = a.FileType,
                UploadedAt = a.UploadedAt
            });
        }
        public async Task<AttachmentResponseDto> GetAttachmentByIdAsync(int id)
        {
            var attachment = await _attachmentRepository.GetAttachmentByIdAsync(id);

            if (attachment == null)
                throw new NotFoundException("Attachment not found");

            return new AttachmentResponseDto
            {
                AttachmentId = attachment.AttachmentId,
                RecordId = attachment.RecordId,
                FileName = attachment.FileName,
                FilePath = attachment.FilePath,
                FileType = attachment.FileType,
                UploadedAt = attachment.UploadedAt
            };
        }
        public async Task CreateAttachmentAsync(CreateAttachmentDto dto)
        {
            var attachment = new Attachment
            {
                RecordId = dto.RecordId,
                FileName = dto.FileName,
                FilePath = dto.FilePath,
                FileType = dto.FileType,
                UploadedAt = DateTime.UtcNow
            };

            await _attachmentRepository.CreateAttachmentAsync(attachment);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateAttachmentAsync(int id, UpdateAttachmentDto dto)
        {
            var attachment = await _attachmentRepository.GetAttachmentByIdAsync(id);

            if (attachment == null)
                throw new NotFoundException("Attachment not found");

            attachment.FileName = dto.FileName;
            attachment.FilePath = dto.FilePath;
            attachment.FileType = dto.FileType;

            await _attachmentRepository.UpdateAttachmentAsync(attachment);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteAttachmentByIdAsync(int id)
        {
            var result = await _attachmentRepository.DeleteAttachmentByIdAsync(id);

            if (!result)
                throw new NotFoundException("Attachment not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
