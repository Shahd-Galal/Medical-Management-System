using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Laboratory
{
    public class CreateLabRequestDto
    {
        [Required] 
        public int RecordId { get; set; }
        [Required][MaxLength(100)] 
        public string TestName { get; set; } = null!;
    }
}
