using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Model.Insurance
{
    public class InsuranceProvider : SoftDeletableEntity
    {
        [Key]
        public int InsuranceProviderId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Phone]
        public string? Phone { get; set; }
    }
}