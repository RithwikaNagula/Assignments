using EmergencyAlert.Application.DTOs;
using EmergencyAlert.Domain.Entities;

namespace EmergencyAlert.Application.Interfaces;

public interface IAlertService
{
    Task<Alert> CreateAlertAsync(string userId, CreateAlertDto createAlertDto);
    Task<IEnumerable<Alert>> GetAlertsByUserIdAsync(string userId);
    Task<bool> UpdateAlertStatusAsync(int alertId, string status);
}
