using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalManagementSystem.Model.Patients
{
    public class MedicalHistory : SoftDeletableEntity
    {
        [Key]
        public int MedicalHistoryId { get; set; }
        public int PatientId { get; set; }
        [MaxLength(200)]
        public string? Disease { get; set; }
        [MaxLength(200)]
        public string? Surgery {  get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; } = null!;
    }
}
