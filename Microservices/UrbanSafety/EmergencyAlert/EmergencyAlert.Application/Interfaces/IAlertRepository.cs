using EmergencyAlert.Domain.Entities;

namespace EmergencyAlert.Application.Interfaces;

public interface IAlertRepository
{
    Task<Alert> CreateAlertAsync(Alert alert);
    Task<IEnumerable<Alert>> GetAlertsByUserIdAsync(string userId);
    Task<Alert?> GetAlertByIdAsync(int alertId);
    Task UpdateAlertAsync(Alert alert);
}
