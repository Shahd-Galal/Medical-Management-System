namespace MedicalManagementSystem.Dtos.Insurance
{
    public class PatientInsuranceResponseDto
    {
        public int PatientInsuranceId { get; set; }
        public int PatientId { get; set; }
        public int InsuranceProviderId { get; set; }
        public string PolicyNumber { get; set; } = null!;
        public DateTime ExpiryDate { get; set; }
    }
}
