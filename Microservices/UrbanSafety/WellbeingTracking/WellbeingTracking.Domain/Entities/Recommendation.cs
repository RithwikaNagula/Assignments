using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WellbeingTracking.Domain.Entities;

[Table("Recommendations")]
public class Recommendation
{
    [Key]
    [Column("rec_id")]
    public int RecId { get; set; }

    [Column("stress_range")]
    public string StressRange { get; set; } = string.Empty; // "0-3", "4-7", "8-10"

    [Column("recommendation")]
    public string RecommendationText { get; set; } = string.Empty;
}
