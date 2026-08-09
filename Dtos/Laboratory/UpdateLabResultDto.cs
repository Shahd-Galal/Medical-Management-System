using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Laboratory
{
    public class UpdateLabResultDto
    {
        [Required][MaxLength(1000)] 
        public string Result { get; set; } = null!;
        [MaxLength(500)] 
        public string? Notes { get; set; }
        [MaxLength(500)]
        public string? Attachment { get; set; }
    }
}
