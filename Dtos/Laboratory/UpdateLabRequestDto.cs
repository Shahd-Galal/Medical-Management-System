using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Enums.Laboratory;

namespace MedicalManagementSystem.Dtos.Laboratory
{
    public class UpdateLabRequestDto
    {
        [MaxLength(100)] 
        public string TestName { get; set; } = null!; 
        [Required][MaxLength(20)]
        public LabRequestStatus Status { get; set; } 
    }
}
