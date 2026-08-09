using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Abstractions;

namespace MedicalManagementSystem.Model.Common
{
    public class Notification : SoftDeletableEntity
    {
        [Key]
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(1000)]
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
