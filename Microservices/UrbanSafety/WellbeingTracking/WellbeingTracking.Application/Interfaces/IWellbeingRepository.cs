using WellbeingTracking.Domain.Entities;

namespace WellbeingTracking.Application.Interfaces;

public interface IWellbeingRepository
{
    Task<WellbeingLog> CreateLogAsync(WellbeingLog log);
    Task<IEnumerable<WellbeingLog>> GetLogsByUserIdAsync(string userId);
    Task<Recommendation?> GetRecommendationByStressLevelAsync(int stressLevel);
}
