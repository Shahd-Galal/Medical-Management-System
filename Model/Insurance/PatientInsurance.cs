using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Model.Patients;
using MedicalManagementSystem.Models.Patients;

namespace MedicalManagementSystem.Model.Insurance
{
    public class PatientInsurance : SoftDeletableEntity
    {
        [Key]
        public int PatientInsuranceId { get; set; }
        public int PatientId { get; set; }
        public int InsuranceProviderId { get; set; }
        [Required]
        [MaxLength(50)]
        public string PolicyNumber { get; set; } = null!;
        public DateTime ExpiryDate { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; } = null!;
        [ForeignKey(nameof(InsuranceProviderId))]
        public InsuranceProvider InsuranceProvider { get; set; } = null!;
    }
}