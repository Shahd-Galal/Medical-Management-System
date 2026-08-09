using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Enums.Laboratory;
using MedicalManagementSystem.Model.MedicalRecords;
using MedicalManagementSystem.Models.Doctors;

namespace MedicalManagementSystem.Model.Laboratory
{
    public class LabRequest : SoftDeletableEntity
    {
        [Key]
        public int LabRequestId { get; set; }
        public int RecordId { get; set; }
        public int DoctorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TestName { get; set; }
        public LabRequestStatus Status { get; set; } 
        [ForeignKey(nameof(RecordId))]
        public MedicalRecord MedicalRecord { get; set; } = null!;
        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;
        public LabResult? LabResult { get; set; }
    }
}
