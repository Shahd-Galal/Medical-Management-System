namespace MedicalManagementSystem.Dtos.Laboratory
{
    public class LabResultResponseDto
    {
        public int LabResultId { get; set; }
        public int LabRequestId { get; set; }
        public string Result { get; set; } = null!;
        public string? Notes { get; set; }
        public string? Attachment { get; set; }
        public DateTime ResultDate { get; set; }
    }
}
