using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Model.Appointments;
using MedicalManagementSystem.Model.Patients;
using MedicalManagementSystem.Models.Doctors;

namespace MedicalManagementSystem.Model.MedicalRecords
{
    public class MedicalRecord : SoftDeletableEntity
    {
        [Key]
        public int MedicalRecordId { get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        [MaxLength(1000)]
        public string? Diagnosis {  get; set; }
        [MaxLength(1000)]
        public string? TreatmentPlan { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(AppointmentId))]
        public Appointment Appointment { get; set; } = null!;
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; } = null!;
        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;
    }
}
