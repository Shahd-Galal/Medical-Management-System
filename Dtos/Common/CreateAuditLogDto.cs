using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Common
{
    public class CreateAuditLogDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Action { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string EntityName { get; set; } = null!;
        [Required]
        public int EntityId { get; set; }
    }
}
