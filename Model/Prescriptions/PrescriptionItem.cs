using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Models.Medicine;
namespace MedicalManagementSystem.Model.Prescriptions
{
    public class PrescriptionItem : SoftDeletableEntity
    {
        [Key]
        public int PrescriptionItemId { get; set; }
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
        [MaxLength(100)]
        public string? Dosage {  get; set; }
        [MaxLength(100)]
        public string? Frequency { get; set; }
        [Range(1, 3650)]
        public int DurationDays { get; set; }
        [MaxLength(500)]
        public string? Instructions { get; set; }
        [ForeignKey(nameof(PrescriptionId))]
        public Prescription Prescription { get; set; } = null!;
        [ForeignKey(nameof(MedicineId))]
        public Medicine Medicine { get; set; } = null!;
    }
}
