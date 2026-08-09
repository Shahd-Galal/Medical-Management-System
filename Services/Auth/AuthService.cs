using MedicalManagementSystem.Dtos.Auth;
using MedicalManagementSystem.Dtos.Doctors;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Auth;
using MedicalManagementSystem.Services.Doctors;
using Microsoft.AspNetCore.Identity;

namespace MedicalManagementSystem.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IDoctorService _doctorService;
        public AuthService(UserManager<User> userManager,RoleManager<Role> roleManager,IJwtTokenGenerator tokenGenerator,
            IDoctorService doctorService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenGenerator = tokenGenerator;
            _doctorService = doctorService;
        }
        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            var user = await CreateUserAsync(dto.FullName, dto.Email, dto.Password, AppRoles.Patient);
            return BuildAuthResponse(user, new[] { AppRoles.Patient });
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                throw new BadRequestException("Invalid email or password.");

            if (!user.IsActive)
                throw new BadRequestException("This account is deactivated.");

            var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!passwordValid)
                throw new BadRequestException("Invalid email or password.");

            var roles = await _userManager.GetRolesAsync(user);
            return BuildAuthResponse(user, roles);
        }
        public async Task RegisterDoctorAsync(RegisterDoctorDto dto)
        {
            var user = await CreateUserAsync(dto.FullName, dto.Email, dto.Password, AppRoles.Doctor);

            try
            {
                await _doctorService.CreateDoctorAsync(new CreateDoctorDto
                {
                    UserId = user.Id,
                    DepartmentId = dto.DepartmentId,
                    LicenseNumber = dto.LicenseNumber,
                    ExperienceYears = dto.ExperienceYears,
                    ConsultationFee = dto.ConsultationFee
                });
            }
            catch
            {
                await _userManager.DeleteAsync(user);
                throw;
            }
        }
        private async Task<User> CreateUserAsync(
            string fullName,
            string email,
            string password,
            string roleName)
        {
            if (await _userManager.FindByEmailAsync(email) != null)
                throw new BadRequestException("Email already exists.");

            var role = await EnsureRoleAsync(roleName);
            var user = new User
            {
                UserName = email,
                Email = email,
                FullName = fullName,
                RoleId = role.Id
            };
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new BadRequestException(errors);
            }
            await _userManager.AddToRoleAsync(user, roleName);
            return user;
        }
        private async Task<Role> EnsureRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                role = new Role { Name = roleName };
                await _roleManager.CreateAsync(role);
            }

            return role;
        }
        private AuthResponseDto BuildAuthResponse(User user, IEnumerable<string> roles)
        {
            var (token, expiresAt) = _tokenGenerator.GenerateToken(user, roles);

            return new AuthResponseDto
            {
                Token = token,
                Email = user.Email!,
                FullName = user.FullName,
                ExpiresAt = expiresAt
            };
        }
    }
}
