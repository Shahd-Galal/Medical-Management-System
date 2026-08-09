namespace MedicalManagementSystem.Dtos.Prescriptions
{
    public class PrescriptionResponseDto
    {
        public int PrescriptionId { get; set; }
        public int RecordId { get; set; }
        public int DoctorId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
