using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Abstractions;

namespace MedicalManagementSystem.Model.Hospital
{
    public class Department : SoftDeletableEntity
    {
        [Key]
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(500)]
        public string? Description { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; } = null!;
    }
}
