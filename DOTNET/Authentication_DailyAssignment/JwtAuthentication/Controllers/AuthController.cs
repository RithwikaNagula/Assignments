using JwtAuthentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace JwtAuthentication.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtsettings;
        public AuthController(JwtSettings jwtsettings)
        {
            _jwtsettings = jwtsettings;
        }


        [HttpPost("token")]
        public IActionResult GenerateToken()
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, "testuser"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtsettings.SecretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtsettings.Issuer,
                audience: _jwtsettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtsettings.ExpiryMinutes),
                signingCredentials: creds
            );

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}