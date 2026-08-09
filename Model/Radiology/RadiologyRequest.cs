using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Enums.Radiology;
using MedicalManagementSystem.Model.MedicalRecords;
using MedicalManagementSystem.Models.Doctors;

namespace MedicalManagementSystem.Model.Radiology
{
    public class RadiologyRequest : SoftDeletableEntity
    {
        [Key]
        public int RadiologyRequestId { get; set; }
        public int RecordId { get; set; }
        public int DoctorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ScanType { get; set; } = null!;
        public RadiologyRequestStatus Status { get; set; } 
        [ForeignKey(nameof(RecordId))]
        public MedicalRecord MedicalRecord { get; set; } = null!;
        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;
        public RadiologyResult? RadiologyResult { get; set; }
    }
}
