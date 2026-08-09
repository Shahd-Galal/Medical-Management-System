using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Hospital
{
    public class CreateBranchDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string? Address { get; set; }
        [Phone]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^01[0125][0-9]{8}$",
        ErrorMessage = "Please enter a valid Egyptian mobile number.")]
        public string? Phone { get; set; }
    }
}
