using EmergencyAlert.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmergencyAlert.Infrastructure.Data;

public class AlertDbContext : DbContext
{
    public AlertDbContext(DbContextOptions<AlertDbContext> options) : base(options) { }

    public DbSet<Alert> Alerts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}
