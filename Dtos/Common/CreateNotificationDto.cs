using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Common
{
    public class CreateNotificationDto
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(1000)]
        public string Message { get; set; } = null!;
    }
}
