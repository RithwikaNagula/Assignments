using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IEmployeeRepository employeeRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByUsernameAsync(dto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            var token = GenerateJwtToken(user);

            return new LoginResponseDto
            {
                Token = token,
                Role = user.Role,
                Username = user.Username
            };
        }

        public async Task<LoginResponseDto?> RegisterAsync(RegisterDto dto)
        {
            // Check if username already exists
            var existingUser = await _userRepository.GetByUsernameAsync(dto.Username);
            if (existingUser != null) return null;

            // Check if email already exists
            var existingEmail = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingEmail != null) return null;

            // Create the User record (authentication)
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };

            await _userRepository.AddAsync(user);

            // Create the Employee record (business data) linked to User
            var employee = new Employee
            {
                Name = dto.Username,
                Email = dto.Email,
                Department = "Unassigned",
                Salary = 0,
                Role = dto.Role,
                UserId = user.Id
            };
            await _employeeRepository.AddAsync(employee);

            var token = GenerateJwtToken(user);

            return new LoginResponseDto
            {
                Token = token,
                Role = user.Role,
                Username = user.Username
            };
        }

        public async Task<bool> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null) return false;

            // In production, send an email with a reset token/link.
            // For now, return true to indicate the email was found.
            return true;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null) return false;

            // In production, validate the reset token.
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            await _userRepository.UpdateAsync(user);

            return true;
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("username", user.Username),
                new Claim("role", user.Role),
                new Claim("userId", user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
