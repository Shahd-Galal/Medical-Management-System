using MedicalManagementSystem.Enums.Laboratory;

namespace MedicalManagementSystem.Dtos.Laboratory
{
    public class LabRequestResponseDto
    {
        public int LabRequestId { get; set; }
        public int RecordId { get; set; }
        public int DoctorId { get; set; }
        public string TestName { get; set; } = null!;
        public LabRequestStatus Status { get; set; } 
    }
}
