namespace MedicalManagementSystem.Dtos.Common
{
    public class AuditLogResponseDto
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; } = null!;
        public string EntityName { get; set; } = null!;
        public int EntityId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
