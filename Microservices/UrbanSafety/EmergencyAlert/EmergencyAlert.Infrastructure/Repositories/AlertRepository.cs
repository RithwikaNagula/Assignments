using EmergencyAlert.Application.Interfaces;
using EmergencyAlert.Domain.Entities;
using EmergencyAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmergencyAlert.Infrastructure.Repositories;

public class AlertRepository : IAlertRepository
{
    private readonly AlertDbContext _context;

    public AlertRepository(AlertDbContext context)
    {
        _context = context;
    }

    public async Task<Alert> CreateAlertAsync(Alert alert)
    {
        _context.Alerts.Add(alert);
        await _context.SaveChangesAsync();
        return alert;
    }

    public async Task<IEnumerable<Alert>> GetAlertsByUserIdAsync(string userId)
    {
        return await _context.Alerts.Where(a => a.UserId == userId).ToListAsync();
    }

    public async Task<Alert?> GetAlertByIdAsync(int alertId)
    {
        return await _context.Alerts.FindAsync(alertId);
    }

    public async Task UpdateAlertAsync(Alert alert)
    {
        _context.Alerts.Update(alert);
        await _context.SaveChangesAsync();
    }
}
