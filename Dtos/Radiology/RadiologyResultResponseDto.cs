namespace MedicalManagementSystem.Dtos.Radiology
{
    public class RadiologyResultResponseDto
    {
        public int RadiologyResultId { get; set; }
        public int RadiologyRequestId { get; set; }
        public string Report { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public DateTime ResultDate { get; set; }
    }
}
