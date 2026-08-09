namespace MedicalManagementSystem.Dtos.MedicalRecords
{
    public class MedicalRecordResponseDto
    {
        public int MedicalRecordId { get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string? Diagnosis { get; set; }
        public string? TreatmentPlan { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
