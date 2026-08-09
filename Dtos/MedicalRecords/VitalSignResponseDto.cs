namespace MedicalManagementSystem.Dtos.MedicalRecords
{
    public class VitalSignResponseDto
    {
        public int VitalSignId { get; set; }
        public int RecordId { get; set; }
        public decimal? Temperature { get; set; }
        public string? BloodPressure { get; set; }
        public int? Pulse { get; set; }
        public int? RespiratoryRate { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
    }
}
