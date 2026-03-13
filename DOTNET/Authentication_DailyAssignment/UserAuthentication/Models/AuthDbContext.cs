using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Models
{
    public class AuthDbContext:DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        
    }
}
