using Microsoft.EntityFrameworkCore;
using WellbeingTracking.Application.Interfaces;
using WellbeingTracking.Domain.Entities;
using WellbeingTracking.Infrastructure.Data;

namespace WellbeingTracking.Infrastructure.Repositories;

public class WellbeingRepository : IWellbeingRepository
{
    private readonly WellbeingDbContext _context;

    public WellbeingRepository(WellbeingDbContext context)
    {
        _context = context;
    }

    public async Task<WellbeingLog> CreateLogAsync(WellbeingLog log)
    {
        _context.Logs.Add(log);
        await _context.SaveChangesAsync();
        return log;
    }

    public async Task<IEnumerable<WellbeingLog>> GetLogsByUserIdAsync(string userId)
    {
        return await _context.Logs.Where(l => l.UserId == userId).ToListAsync();
    }

    public async Task<Recommendation?> GetRecommendationByStressLevelAsync(int stressLevel)
    {
        string range = stressLevel switch
        {
            >= 8 => "8-10",
            >= 4 => "4-7",
            _ => "0-3"
        };
        
        return await _context.Recommendations.FirstOrDefaultAsync(r => r.StressRange == range);
    }
}
