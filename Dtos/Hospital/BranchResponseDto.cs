using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Hospital
{
    public class BranchResponseDto
    {
        public int BranchId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
