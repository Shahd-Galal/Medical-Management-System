using MedicalManagementSystem.Model.Common;

namespace MedicalManagementSystem.Repositories.Common
{
    // AuditLog is append-only: it can be created and read, but not edited or deleted.
    public interface IAuditLogRepository
    {
        Task<IEnumerable<AuditLog>> GetAllAuditLogsAsync();
        Task<AuditLog?> GetAuditLogByIdAsync(int id);
        Task CreateAuditLogAsync(AuditLog auditLog);
    }
}
