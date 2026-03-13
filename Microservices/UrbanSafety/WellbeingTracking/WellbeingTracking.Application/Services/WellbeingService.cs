using WellbeingTracking.Application.DTOs;
using WellbeingTracking.Application.Interfaces;
using WellbeingTracking.Domain.Entities;

namespace WellbeingTracking.Application.Services;

public class WellbeingService : IWellbeingService
{
    private readonly IWellbeingRepository _repository;

    public WellbeingService(IWellbeingRepository repository)
    {
        _repository = repository;
    }

    public async Task<WellbeingLog> LogWellbeingAsync(string userId, LogWellbeingDto logDto)
    {
        var log = new WellbeingLog
        {
            UserId = userId,
            Mood = logDto.Mood,
            StressLevel = logDto.StressLevel,
            SleepHours = logDto.SleepHours,
            CreatedAt = DateTime.UtcNow
        };

        return await _repository.CreateLogAsync(log);
    }

    public async Task<IEnumerable<WellbeingLog>> GetUserLogsAsync(string userId)
    {
        return await _repository.GetLogsByUserIdAsync(userId);
    }

    public async Task<Recommendation?> GetRecommendationAsync(int stressLevel)
    {
        return await _repository.GetRecommendationByStressLevelAsync(stressLevel);
    }
}
