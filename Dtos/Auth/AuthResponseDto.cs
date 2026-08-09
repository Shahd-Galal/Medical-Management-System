namespace MedicalManagementSystem.Dtos.Auth
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
    }
}
