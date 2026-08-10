using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Enums.Laboratory;

namespace MedicalManagementSystem.Dtos.Laboratory
{
    public class UpdateLabRequestDto
    {
        [MaxLength(100)] 
        public string TestName { get; set; } = null!; 
        [Required]
        public LabRequestStatus Status { get; set; } 
    }
}
