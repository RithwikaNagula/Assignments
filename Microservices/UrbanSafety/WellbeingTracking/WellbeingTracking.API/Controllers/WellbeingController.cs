using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WellbeingTracking.Application.DTOs;
using WellbeingTracking.Application.Interfaces;

namespace WellbeingTracking.API.Controllers;

[ApiController]
[Route("wellbeing")]
[Authorize]
public class WellbeingController : ControllerBase
{
    private readonly IWellbeingService _wellbeingService;

    public WellbeingController(IWellbeingService wellbeingService)
    {
        _wellbeingService = wellbeingService;
    }

    [HttpPost("log")]
    public async Task<IActionResult> LogWellbeing([FromBody] LogWellbeingDto logDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var log = await _wellbeingService.LogWellbeingAsync(userId, logDto);
        return Ok(log);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserLogs(string userId)
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(currentUserId)) return Unauthorized();

        if (currentUserId != userId && User.FindFirstValue(ClaimTypes.Role) != "Admin")
        {
            return Forbid();
        }

        var logs = await _wellbeingService.GetUserLogsAsync(userId);
        return Ok(logs);
    }

    [HttpGet("recommendation/{stressLevel}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetRecommendation(int stressLevel)
    {
        var recommendation = await _wellbeingService.GetRecommendationAsync(stressLevel);
        if (recommendation == null) return NotFound();

        return Ok(recommendation);
    }
}
