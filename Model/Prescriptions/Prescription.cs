using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Model.MedicalRecords;
using MedicalManagementSystem.Models.Doctors;

namespace MedicalManagementSystem.Model.Prescriptions
{
    public class Prescription : SoftDeletableEntity
    {
        [Key]
        public int PrescriptionId { get; set; }
        public int RecordId { get; set; }
        public int DoctorId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(RecordId))]
        public MedicalRecord MedicalRecord { get; set; } = null!;
        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;
        public ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();
    }
}