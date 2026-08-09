using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Abstractions;

namespace MedicalManagementSystem.Model.Common
{
    public class Attachment : SoftDeletableEntity
    {
        [Key]
        public int AttachmentId { get; set; }
        public int RecordId { get; set; }
        [Required]
        [MaxLength(255)]
        public string FileName { get; set; } = null!;
        [Required]
        [MaxLength(500)]
        public string FilePath { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string FileType { get; set; } = null!;
        public DateTime UploadedAt { get; set; }
    }
}
