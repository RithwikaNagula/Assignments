using Microsoft.EntityFrameworkCore;
using StudentAttendance.Models;
using System.Collections.Generic;

namespace StudentAttendance.Data
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
