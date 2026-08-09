namespace MedicalManagementSystem.Dtos.Billing
{
    public class ServiceResponseDto
    {
        public int ServiceId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
