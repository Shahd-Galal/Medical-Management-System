using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Model.Common
{
    public class AuditLog
    {

        [Key]
        public int LogId { get; set; }
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Action { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string EntityName { get; set; } = null!;
        public int EntityId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
