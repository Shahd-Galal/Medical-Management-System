using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MedicalManagementSystem.Model.Auth
{
    public class User : IdentityUser<int>
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        public int RoleId { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; } = null!;
    }
}