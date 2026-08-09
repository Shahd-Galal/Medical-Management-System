namespace MedicalManagementSystem.Dtos.Insurance
{
    public class InsuranceProviderResponseDto
    {
        public int InsuranceProviderId { get; set; }
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
