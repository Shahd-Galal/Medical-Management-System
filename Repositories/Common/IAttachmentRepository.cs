using MedicalManagementSystem.Model.Common;

namespace MedicalManagementSystem.Repositories.Common
{
    public interface IAttachmentRepository
    {
        Task<IEnumerable<Attachment>> GetAllAttachmentsAsync();
        Task<Attachment?> GetAttachmentByIdAsync(int id);
        Task CreateAttachmentAsync(Attachment attachment);
        Task UpdateAttachmentAsync(Attachment attachment);
        Task<bool> DeleteAttachmentByIdAsync(int id);
    }
}
