using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Insurance
{
    public class UpdateInsuranceProviderDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Phone]
        public string? Phone { get; set; }
    }
}
