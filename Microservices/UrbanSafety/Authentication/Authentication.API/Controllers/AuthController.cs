using Authentication.Application.DTOs;
using Authentication.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto);
        if (!result)
        {
            return BadRequest(new { Message = "Email already exists" });
        }
        return Ok(new { Message = "User registered successfully" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _authService.LoginAsync(loginDto);
        if (result == null)
        {
            return Unauthorized(new { Message = "Invalid credentials" });
        }
        return Ok(result);
    }

    [HttpGet("validateToken")]
    public IActionResult ValidateToken()
    {
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var isValid = _authService.ValidateToken(token);
        if (isValid)
        {
            return Ok(new { Message = "Token is valid" });
        }
        return Unauthorized(new { Message = "Token is invalid" });
    }
}
