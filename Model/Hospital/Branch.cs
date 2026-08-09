using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Abstractions;

namespace MedicalManagementSystem.Model.Hospital
{
    public class Branch : SoftDeletableEntity
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(100)]
        public string? Address { get; set; }
        [Phone]
        public string? Phone { get; set; }
        public ICollection<Department>Departments { get; set; } = new List<Department>();
    }
}
