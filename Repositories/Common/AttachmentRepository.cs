using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Common
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly AppDbContext _context;
        public AttachmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Attachment>> GetAllAttachmentsAsync()
        {
            return await _context.Attachments.ToListAsync();
        }
        public async Task<Attachment?> GetAttachmentByIdAsync(int id)
        {
            return await _context.Attachments.FirstOrDefaultAsync(a => a.AttachmentId == id);
        }
        public async Task CreateAttachmentAsync(Attachment attachment)
        {
            await _context.Attachments.AddAsync(attachment);
        }
        public async Task UpdateAttachmentAsync(Attachment attachment)
        {
            _context.Attachments.Update(attachment);
        }
        public async Task<bool> DeleteAttachmentByIdAsync(int id)
        {
            var attachment = await _context.Attachments
                .FirstOrDefaultAsync(a => a.AttachmentId == id);

            if (attachment == null)
                return false;

            attachment.IsDeleted = true;
            return true;
        }
    }
}
