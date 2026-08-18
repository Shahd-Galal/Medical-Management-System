using MedicalManagementSystem.Dtos.Common;

namespace MedicalManagementSystem.Services.Common
{
    public interface IAttachmentService
    {
        Task<IEnumerable<AttachmentResponseDto>> GetAllAttachmentsAsync();
        Task<AttachmentResponseDto> GetAttachmentByIdAsync(int id);
        Task CreateAttachmentAsync(CreateAttachmentDto dto);
        Task UpdateAttachmentAsync(int id, UpdateAttachmentDto dto);
        Task<bool> DeleteAttachmentByIdAsync(int id);
    }
}
