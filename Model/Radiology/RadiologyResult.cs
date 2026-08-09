using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalManagementSystem.Model.Radiology
{
    public class RadiologyResult : SoftDeletableEntity
    {
        [Key]
        public int RadiologyResultId { get; set; }
        public int RadiologyRequestId { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Report { get; set; } = null!;
        [Required]
        [MaxLength(500)]
        public string ImagePath { get; set; } = null!;
        public DateTime ResultDate { get; set; }
        [ForeignKey(nameof(RadiologyRequestId))]
        public RadiologyRequest RadiologyRequest { get; set; } = null!;

    }
}
