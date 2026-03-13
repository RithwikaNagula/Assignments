using EmergencyAlert.Application.DTOs;
using EmergencyAlert.Application.Interfaces;
using EmergencyAlert.Domain.Entities;

namespace EmergencyAlert.Application.Services;

public class AlertService : IAlertService
{
    private readonly IAlertRepository _alertRepository;

    public AlertService(IAlertRepository alertRepository)
    {
        _alertRepository = alertRepository;
    }

    public async Task<Alert> CreateAlertAsync(string userId, CreateAlertDto createAlertDto)
    {
        var alert = new Alert
        {
            UserId = userId,
            Latitude = createAlertDto.Latitude,
            Longitude = createAlertDto.Longitude,
            AlertTime = DateTime.UtcNow,
            Status = "Active"
        };
        return await _alertRepository.CreateAlertAsync(alert);
    }

    public async Task<IEnumerable<Alert>> GetAlertsByUserIdAsync(string userId)
    {
        return await _alertRepository.GetAlertsByUserIdAsync(userId);
    }

    public async Task<bool> UpdateAlertStatusAsync(int alertId, string status)
    {
        var alert = await _alertRepository.GetAlertByIdAsync(alertId);
        if (alert == null) return false;

        alert.Status = status;
        await _alertRepository.UpdateAlertAsync(alert);
        return true;
    }
}
