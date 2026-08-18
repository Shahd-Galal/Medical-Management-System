using MedicalManagementSystem.Dtos.Common;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Common;
using MedicalManagementSystem.Repositories.Common;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Common
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AuditLogService(IAuditLogRepository auditLogRepository,IUnitOfWork unitOfWork)
        {
            _auditLogRepository = auditLogRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<AuditLogResponseDto>> GetAllAuditLogsAsync()
        {
            var auditLogs = await _auditLogRepository.GetAllAuditLogsAsync();

            return auditLogs.Select(a => new AuditLogResponseDto
            {
                LogId = a.LogId,
                UserId = a.UserId,
                Action = a.Action,
                EntityName = a.EntityName,
                EntityId = a.EntityId,
                Timestamp = a.Timestamp
            });
        }
        public async Task<AuditLogResponseDto> GetAuditLogByIdAsync(int id)
        {
            var auditLog = await _auditLogRepository.GetAuditLogByIdAsync(id);

            if (auditLog == null)
                throw new NotFoundException("Audit log not found");

            return new AuditLogResponseDto
            {
                LogId = auditLog.LogId,
                UserId = auditLog.UserId,
                Action = auditLog.Action,
                EntityName = auditLog.EntityName,
                EntityId = auditLog.EntityId,
                Timestamp = auditLog.Timestamp
            };
        }
        public async Task CreateAuditLogAsync(CreateAuditLogDto dto)
        {
            var auditLog = new AuditLog
            {
                UserId = dto.UserId,
                Action = dto.Action,
                EntityName = dto.EntityName,
                EntityId = dto.EntityId,
                Timestamp = DateTime.UtcNow
            };

            await _auditLogRepository.CreateAuditLogAsync(auditLog);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
