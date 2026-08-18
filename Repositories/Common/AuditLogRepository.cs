using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Common
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly AppDbContext _context;
        public AuditLogRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AuditLog>> GetAllAuditLogsAsync()
        {
            return await _context.AuditLogs.ToListAsync();
        }
        public async Task<AuditLog?> GetAuditLogByIdAsync(int id)
        {
            return await _context.AuditLogs.FirstOrDefaultAsync(a => a.LogId == id);
        }
        public async Task CreateAuditLogAsync(AuditLog auditLog)
        {
            await _context.AuditLogs.AddAsync(auditLog);
        }
    }
}
