using MedicalManagementSystem.Enums.Radiology;

namespace MedicalManagementSystem.Dtos.Radiology
{
    public class RadiologyRequestResponseDto
    {
        public int RadiologyRequestId { get; set; }
        public int RecordId { get; set; }
        public int DoctorId { get; set; }
        public string ScanType { get; set; } = null!;
        public RadiologyRequestStatus Status { get; set; } 
    }
}
