using MedicalManagementSystem.Dtos.Common;

namespace MedicalManagementSystem.Services.Common
{
    public interface IAuditLogService
    {
        Task<IEnumerable<AuditLogResponseDto>> GetAllAuditLogsAsync();
        Task<AuditLogResponseDto> GetAuditLogByIdAsync(int id);
        Task CreateAuditLogAsync(CreateAuditLogDto dto);
    }
}
