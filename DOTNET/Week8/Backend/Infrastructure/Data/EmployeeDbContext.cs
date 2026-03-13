using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Department).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Role).IsRequired().HasMaxLength(20);

                // Self-referencing FK: Manager is also an Employee
                entity.HasOne(e => e.Manager)
                      .WithMany(m => m.Subordinates)
                      .HasForeignKey(e => e.ManagerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Role).IsRequired().HasMaxLength(20);
            });

            // Seed default Admin user (password: Admin@123)
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@employeemngmt.com",
                PasswordHash = "$2a$11$G/D88y/B.DIF/XlW0O5rbe5h8Yt02/K7zR.J9bL05A3c66kXXU56i", // Admin@123
                Role = "Admin"
            });

            // Seed default Admin employee record linked to User 1
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Name = "admin",
                Email = "admin@employeemngmt.com",
                Department = "Management",
                Salary = 0,
                Role = "Admin",
                UserId = 1,
                ManagerId = null
            });
        }
    }
}
