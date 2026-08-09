namespace MedicalManagementSystem.Dtos.Common
{
    public class AttachmentResponseDto
    {
        public int AttachmentId { get; set; }
        public int RecordId { get; set; }
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public DateTime UploadedAt { get; set; }
    }
}
