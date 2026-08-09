namespace MedicalManagementSystem.Dtos.Patients
{
    public class MedicalHistoryResponseDto
    {
        public int MedicalHistoryId { get; set; }
        public int PatientId { get; set; }
        public string? Disease { get; set; }
        public string? Surgery { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
