using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class AttendanceDbContext : DbContext
    {
        // Constructor (needed for Dependency Injection)
        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) : base(options)
        {
        }

        // Tables
        public DbSet<Student> Students { get; set; }

        public DbSet<Attendance> Attendances { get; set; }
    }
}
