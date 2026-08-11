using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Prescriptions
{
    public class CreatePrescriptionDto
    {
        [Required]
        public int RecordId { get; set; }
        [Required]
        public int DoctorId { get; set; }
    }
}
