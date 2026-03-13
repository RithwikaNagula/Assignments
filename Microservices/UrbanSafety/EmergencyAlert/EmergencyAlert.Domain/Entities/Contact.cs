using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyAlert.Domain.Entities;

[Table("EmergencyContacts")]
public class Contact
{
    [Key]
    [Column("contact_id")]
    public int ContactId { get; set; }

    [Column("user_id")]
    public string UserId { get; set; } = string.Empty;

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("phone")]
    public string Phone { get; set; } = string.Empty;
}
