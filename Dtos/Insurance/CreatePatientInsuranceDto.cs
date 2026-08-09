using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Insurance
{
    public class CreatePatientInsuranceDto
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int InsuranceProviderId { get; set; }
        [Required]
        [MaxLength(50)]
        public string PolicyNumber { get; set; } = null!;
        public DateTime ExpiryDate { get; set; }
    }
}
