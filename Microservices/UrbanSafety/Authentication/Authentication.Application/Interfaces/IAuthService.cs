using Authentication.Application.DTOs;

namespace Authentication.Application.Interfaces;

public interface IAuthService
{
    Task<TokenDto?> LoginAsync(LoginDto loginDto);
    Task<bool> RegisterAsync(RegisterDto registerDto);
    bool ValidateToken(string token);
}
