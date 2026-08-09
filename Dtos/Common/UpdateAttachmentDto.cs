using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Common
{
    public class UpdateAttachmentDto
    {
        [Required]
        [MaxLength(255)]
        public string FileName { get; set; } = null!;
        [Required]
        [MaxLength(500)]
        public string FilePath { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string FileType { get; set; } = null!;
    }
}
