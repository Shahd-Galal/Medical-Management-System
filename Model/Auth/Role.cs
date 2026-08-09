using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MedicalManagementSystem.Model.Auth
{
    public class Role : IdentityRole<int>
    {
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}