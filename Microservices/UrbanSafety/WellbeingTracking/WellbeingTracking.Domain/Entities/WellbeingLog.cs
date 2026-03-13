using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WellbeingTracking.Domain.Entities;

[Table("WellbeingLogs")]
public class WellbeingLog
{
    [Key]
    [Column("log_id")]
    public int LogId { get; set; }

    [Column("user_id")]
    public string UserId { get; set; } = string.Empty;

    [Column("mood")]
    public string Mood { get; set; } = string.Empty;

    [Column("stress_level")]
    public int StressLevel { get; set; } // 0-10

    [Column("sleep_hours")]
    public double SleepHours { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
