using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyAlert.Domain.Entities;

[Table("EmergencyAlerts")]
public class Alert
{
    [Key]
    [Column("alert_id")]
    public int AlertId { get; set; }

    [Column("user_id")]
    public string UserId { get; set; } = string.Empty;

    [Column("latitude")]
    public double Latitude { get; set; }

    [Column("longitude")]
    public double Longitude { get; set; }

    [Column("alert_time")]
    public DateTime AlertTime { get; set; } = DateTime.UtcNow;

    [Column("status")]
    public string Status { get; set; } = "Active"; // Active, Resolved
}
