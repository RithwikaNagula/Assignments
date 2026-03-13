using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Authentication.Domain.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = "User";
    public List<string> EmergencyContacts { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
