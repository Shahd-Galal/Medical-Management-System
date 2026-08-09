using MedicalManagementSystem.Model.Auth;

namespace MedicalManagementSystem.Services.Auth
{
    public interface IJwtTokenGenerator
    {
        (string Token, DateTime ExpiresAt) GenerateToken(User user,IEnumerable<string> roles);
    }
}
