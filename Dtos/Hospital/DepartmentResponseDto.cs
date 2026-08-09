namespace MedicalManagementSystem.Dtos.Hospital
{
    public class DepartmentResponseDto
    {
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
