using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalManagementSystem.Model.Laboratory
{
    public class LabResult : SoftDeletableEntity
    {
        [Key]
        public int LabResultId { get; set; }
        public int LabRequestId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Result { get; set; } = null!;
        [MaxLength(500)]
        public string? Notes { get; set; }
        [MaxLength(500)]
        public string? Attachment { get; set; }
        public DateTime ResultDate { get; set; }
        [ForeignKey(nameof(LabRequestId))]
        public LabRequest LabRequest { get; set; } = null!;
    }
}

