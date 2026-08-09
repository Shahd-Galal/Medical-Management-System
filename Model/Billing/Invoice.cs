using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Abstractions;
using MedicalManagementSystem.Enums.Billing;
using MedicalManagementSystem.Model.Appointments;
using MedicalManagementSystem.Model.Patients;

namespace MedicalManagementSystem.Model.Billing
{
    public class Invoice : SoftDeletableEntity
    {
        [Key]
        public int InvoiceId { get; set; }
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        [Range(0, double.MaxValue)]
        public decimal TotalAmount { get; set; }
        public InvoiceStatus Status { get; set; } 
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; } = null!;
        [ForeignKey(nameof(AppointmentId))]
        public Appointment Appointment { get; set; } = null!;
    }
}