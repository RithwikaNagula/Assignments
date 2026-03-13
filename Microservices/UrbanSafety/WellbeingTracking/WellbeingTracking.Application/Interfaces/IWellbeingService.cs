using WellbeingTracking.Application.DTOs;
using WellbeingTracking.Domain.Entities;

namespace WellbeingTracking.Application.Interfaces;

public interface IWellbeingService
{
    Task<WellbeingLog> LogWellbeingAsync(string userId, LogWellbeingDto logDto);
    Task<IEnumerable<WellbeingLog>> GetUserLogsAsync(string userId);
    Task<Recommendation?> GetRecommendationAsync(int stressLevel);
}
