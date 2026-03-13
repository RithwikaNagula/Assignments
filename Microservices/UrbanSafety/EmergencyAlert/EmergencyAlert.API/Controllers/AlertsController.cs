using EmergencyAlert.Application.DTOs;
using EmergencyAlert.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmergencyAlert.API.Controllers;

[ApiController]
[Route("alerts")]
[Authorize]
public class AlertsController : ControllerBase
{
    private readonly IAlertService _alertService;

    public AlertsController(IAlertService alertService)
    {
        _alertService = alertService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAlert([FromBody] CreateAlertDto createAlertDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var alert = await _alertService.CreateAlertAsync(userId, createAlertDto);
        return Ok(alert);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserAlerts(string userId)
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(currentUserId)) return Unauthorized();

        if (currentUserId != userId && User.FindFirstValue(ClaimTypes.Role) != "Admin") 
        {
            return Forbid();
        }

        var alerts = await _alertService.GetAlertsByUserIdAsync(userId);
        return Ok(alerts);
    }

    [HttpPut("updateStatus/{alertId}")]
    public async Task<IActionResult> UpdateAlertStatus(int alertId, [FromBody] UpdateAlertStatusDto updateDto)
    {
        var result = await _alertService.UpdateAlertStatusAsync(alertId, updateDto.Status);
        if (!result) return NotFound(new { Message = "Alert not found" });

        return Ok(new { Message = "Status updated successfully" });
    }
}
