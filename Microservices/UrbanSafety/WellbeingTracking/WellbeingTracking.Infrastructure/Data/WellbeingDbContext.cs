using Microsoft.EntityFrameworkCore;
using WellbeingTracking.Domain.Entities;

namespace WellbeingTracking.Infrastructure.Data;

public class WellbeingDbContext : DbContext
{
    public WellbeingDbContext(DbContextOptions<WellbeingDbContext> options) : base(options) { }

    public DbSet<WellbeingLog> Logs { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Recommendation>().HasData(
            new Recommendation { RecId = 1, StressRange = "0-3", RecommendationText = "Suggest productivity or mindfulness tips" },
            new Recommendation { RecId = 2, StressRange = "4-7", RecommendationText = "Suggest physical activity or short breaks" },
            new Recommendation { RecId = 3, StressRange = "8-10", RecommendationText = "Suggest breathing or relaxation exercises" }
        );
    }
}
